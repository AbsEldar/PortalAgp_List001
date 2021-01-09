using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class LstDefault: BaseList
    {
        public virtual ICollection<LstDefault> Childrens {get; set;}
        public virtual LstDefault Parent {get; set;}
        public Guid? ParentId { get; set; }
    }
}