using API.Dtos.User;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class UserUrlResolver : IValueResolver<User, UserToReturnDto, string>
    {

        private readonly IConfiguration _config;
        public UserUrlResolver (IConfiguration config) 
       {
            _config = config;
       }
        public string Resolve(User source, UserToReturnDto destination, string destMember, ResolutionContext context)
        {
               if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
 
            return null;

        }
    }
}