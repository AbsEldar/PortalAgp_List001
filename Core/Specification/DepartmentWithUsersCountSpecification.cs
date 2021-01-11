using Core.Entities;

namespace Core.Specification
{
    public class DepartmentWithUsersCountSpecification: BaseSpecification<Department>
    {
        public DepartmentWithUsersCountSpecification(DepartmentSpecParams departmentParams): base(x => 
            (string.IsNullOrEmpty(departmentParams.Search) || x.Name.ToLower().Contains(departmentParams.Search)))
        {
            
        }
    }
}