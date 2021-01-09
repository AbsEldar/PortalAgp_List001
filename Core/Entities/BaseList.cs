using System;
using System.Collections.Generic;
using Core.Enums;

namespace Core.Entities
{
    public class BaseList: BaseEntity
    {
        public string Name { get; set; }
        public string KeyIndex { get; set; }
        public LstTypeItem LstTypeItem { get; set; }
        public LstTypeClass LstTypeClass { get; set; }
        public bool IsDeleted { get; set; } = false;
        
        
    }
}