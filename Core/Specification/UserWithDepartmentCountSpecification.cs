using Core.Entities;

namespace Core.Specification
{
    public class UserWithDepartmentCountSpecification: BaseSpecification<User>
    {
        public UserWithDepartmentCountSpecification(UserSpecParams userSpecParams): base(x => 
            (string.IsNullOrEmpty(userSpecParams.Search) || x.Name.ToLower().Contains(userSpecParams.Search)))
        {
            
        }
    }
}