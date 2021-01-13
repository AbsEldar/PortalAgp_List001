using System;
using Core.Entities;

namespace Core.Specification
{
    public class UserWithDepartmentOnlySpecification: BaseSpecification<User>
    {
        public UserWithDepartmentOnlySpecification()
        {
            AddInclude(x => x.Department);
        }

        public UserWithDepartmentOnlySpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Department);
        }
    }
}