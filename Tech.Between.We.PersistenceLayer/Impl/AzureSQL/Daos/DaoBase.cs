using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Orm.DbContexts;

namespace Tech.Between.We.PersistenceLayer.Impl.AzureSQL.Daos
{
  public abstract class DaoBase
    {
        protected WeDbContext weDbContext;

        public DaoBase(WeDbContext weDbContext)
        {
            this.weDbContext = weDbContext;
        }

        protected EntityBase SetEntityState(EntityBase entity, bool updateForeignKeys = true)
        {
            if (!(entity is EntityBase))
            {
                return null;
            }

            if (updateForeignKeys)
            {
                UpdateForeignKeys(entity);
            }

            SetEntity(entity);

            foreach (System.Reflection.PropertyInfo prop in entity.GetType().GetProperties())
            {
                if (prop.GetValue(entity) != null)
                {
                    if (prop.GetValue(entity) is EntityBase)
                    {
                        SetEntityState((EntityBase)prop.GetValue(entity),false);
                    }
                    else if (prop.GetValue(entity).GetType().IsGenericType)
                    {
                        foreach (object element in (prop.GetValue(entity) as
                            IEnumerable<object>).Cast<object>().ToList())
                        {
                            if (element is EntityBase)
                            {
                                SetEntityState((EntityBase)element,false);
                            }
                        }
                    }
                }
            }

            return entity;
        }

        protected EntityBase SetEntity(EntityBase entity, bool remove = false)
        {
            if (!(entity is EntityBase)) {
                return null;
            }

            EntityState state = EntityState.Unchanged;

            //Si la entidad se ha guardado ya y esta marcada como para eliminar, se borra de la bbdd

            if (entity.DbInsertedDate != null && entity.DeletedDate != null)
            {
                state = EntityState.Deleted;
            }
            //Si no se ha insertado aún y no esta marcado para eliminar, se inserta
            else if (entity.DbInsertedDate == null && entity.DeletedDate == null)
            {
                state = EntityState.Added;
            }
            //Si no se ha insertado en bbdd aún y pero esta marcado para eliminar, no haces nada.
            else if (entity.DbInsertedDate == null && entity.DeletedDate != null)
            {
                state = EntityState.Detached;
            }
            //Si ya esta en BBDD y no se ha de eliminar. lo modificamos
            else if (entity.DbInsertedDate != null && entity.DeletedDate == null)
            {
                state = EntityState.Modified;
            }

            weDbContext.Entry(entity).State = state;

            return entity;
        }

        protected EntityBase UpdateForeignKeys(EntityBase entity)
        {
            if (!(entity is EntityBase))
            {
                return null;
            }

            foreach (System.Reflection.PropertyInfo prop in entity.GetType().GetProperties())
            {
                if (prop.GetValue(entity) != null)
                {
                    if (prop.GetValue(entity) is EntityBase)
                    {
                        System.Reflection.PropertyInfo propId =
                            entity.GetType().GetProperty($"{ prop.Name }Id");

                        propId.SetValue(entity,((EntityBase) prop.GetValue(entity)).Id);

                        UpdateForeignKeys((EntityBase)prop.GetValue(entity));
                    }
                    else if (prop.GetValue(entity).GetType().IsGenericType)
                    {
                        foreach (object element in (prop.GetValue(entity) as
                            IEnumerable<object>).Cast<object>().ToList())
                        {
                            if (element is EntityBase)
                            {
                                UpdateForeignKeys((EntityBase)element);
                            }                   
                        }
                    }
                }
            }

            return entity;
        }

    }
}
