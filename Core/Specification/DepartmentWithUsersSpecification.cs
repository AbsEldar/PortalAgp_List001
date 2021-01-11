using System;
using Core.Entities;

namespace Core.Specification
{
    public class DepartmentWithUsersSpecification: BaseSpecification<Department>
    {
        public DepartmentWithUsersSpecification(DepartmentSpecParams departmentParams)
            :base(x => (string.IsNullOrEmpty(departmentParams.Search) || x.Name.ToLower().Contains(departmentParams.Search)))
        {
            AddInclude(x => x.Users);
            ApplyPaging(departmentParams.PageSize * (departmentParams.PageIndex -1), departmentParams.PageSize);


            if(!string.IsNullOrEmpty(departmentParams.Sort))
            {
                switch(departmentParams.Sort)
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

        public DepartmentWithUsersSpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Users);
        }
    }
}