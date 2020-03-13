using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;
using Tech.Between.We.EntitiesLayer.Entities.FileDatas;
using Tech.Between.We.EntitiesLayer.Entities.NmNews.Tags;
using Tech.Between.We.EntitiesLayer.Entities.Persons;

namespace Tech.Between.We.EntitiesLayer.Entities.NmNews
{
    public class News: EntityBase
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public bool? Confidential { get; set; }
        public DateTime? Date { get; set; }

        public virtual User Author { get; set; }
        public Guid? AuthorId { get; set; }
        public virtual NewsSubType NewsSubType { get; set; }
        public Guid? NewsSubTypeId { get; set; }

        public virtual List<NewsPersonTag> TaggedPeople { get; set; }
        public virtual List<NewsCompanyTag> TaggedCompanies { get; set; }
        public virtual List<NewsProjectTag> TaggedProjects { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<FileData> Files { get; set; }


        public News() {
            TaggedPeople = new List<NewsPersonTag>();
            TaggedCompanies = new List<NewsCompanyTag>();
            TaggedProjects = new List<NewsProjectTag>();
            Comments = new List<Comment>();
            Files = new List<FileData>();
           }

    }
}
