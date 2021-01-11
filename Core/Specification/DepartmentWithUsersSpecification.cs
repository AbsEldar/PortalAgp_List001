using System;
using Core.Entities;

namespace Core.Specification
{
    public class DepartmentWithUsersSpecification: BaseSpecification<Department>
    {
        public DepartmentWithUsersSpecification()
        {
            AddInclude(x => x.Users);
        }

        public DepartmentWithUsersSpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Users);
        }
    }
}