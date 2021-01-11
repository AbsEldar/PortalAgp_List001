using System;

namespace Core.Entities
{
    public class User: BaseEntity
    {
        public string Name { get; set; }
        public virtual Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}