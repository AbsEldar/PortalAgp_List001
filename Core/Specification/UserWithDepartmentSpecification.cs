using System;
using Core.Entities;

namespace Core.Specification
{
    public class UserWithDepartmentSpecification: BaseSpecification<User>
    {
        public UserWithDepartmentSpecification(UserSpecParams userSpecParams) 
            :base(x => (string.IsNullOrEmpty(userSpecParams.Search) || x.Name.ToLower().Contains(userSpecParams.Search))
            && (!userSpecParams.DepartmentId.HasValue || x.DepartmentId == userSpecParams.DepartmentId)
            )
        {
            AddInclude(x => x.Department);
            ApplyPaging(userSpecParams.PageSize * (userSpecParams.PageIndex -1), userSpecParams.PageSize);

             if(!string.IsNullOrEmpty(userSpecParams.Sort))
            {
                switch(userSpecParams.Sort)
                {
                    case "nameAsc":
                        AddOrderBy(p => p.Name);
                        break;
                    case "nameDesc":
                        AddOrderByDescending(p => p.Name);
                        break;
                    default: 
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public UserWithDepartmentSpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Department);
        }
    }
}