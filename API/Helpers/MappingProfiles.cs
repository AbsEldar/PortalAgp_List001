using System.Collections.Generic;
using API.Dtos.Lsts;
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
        }
    }
}