using System;
using System.Collections.Generic;
using System.Text;
using Tech.Between.We.EntitiesLayer.Entities.Bases;

namespace Tech.Between.We.EntitiesLayer.Entities.FileDatas
{
  public  class FileData:EntityBase
    {
        public Guid? FileId { get; set; }
        public string AuthKey { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public string ContentType { get; set; }
    }
}
