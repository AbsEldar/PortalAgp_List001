using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class LstOrder: BaseList
    {
        public string OrderCode { get; set; }
        public virtual ICollection<LstOrder> Childrens {get; set;}
        public virtual LstOrder Parent {get; set;}
        public Guid? ParentId { get; set; }
    }
}