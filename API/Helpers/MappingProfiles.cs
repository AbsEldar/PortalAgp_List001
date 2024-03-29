using System.Collections.Generic;
using API.Dtos.Department;
using API.Dtos.Lsts;
using API.Dtos.User;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<LstDog, LstDogToReturnDto>();
            CreateMap<IReadOnlyList<LstDog>, IReadOnlyList<LstDogToReturnDto>>();

            CreateMap<User, UserToReturnDto>()
            .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.Department.Name))
            .ForMember(d => d.PictureUrl, o => o.MapFrom<UserUrlResolver>());

            CreateMap<User, UserForAccessLstDto>();

            CreateMap<Department, DepartmentToReturnDto>();

            CreateMap<LstDog, LstBreadCrambDto>();
            // CreateMap<IReadOnlyList<Department>, IReadOnlyList<DepartmentToReturnDto>>();
            

            // CreateMap<IReadOnlyList<User>, IReadOnlyList<UserToReturnDto>>();
        }
    }
}