using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class LstDog: BaseList
    {
        public string DogAuthor { get; set; }
        public virtual ICollection<LstDog> Childrens {get; set;}
        public virtual LstDog Parent {get; set;}
        public Guid? ParentId { get; set; }
    }
}