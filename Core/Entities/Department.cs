using System.Collections.Generic;

namespace Core.Entities
{
    public class Department: BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}