using System;

namespace API.Dtos.User
{
    public class UserToReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
    }
}