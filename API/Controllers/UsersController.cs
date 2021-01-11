using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.User;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IMapper _mapper;
        public UsersController(IGenericRepository<User> userRepo, IMapper mapper)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet("getAllWithSpec")]
        public async Task<ActionResult<Pagination<UserToReturnDto>>> GetAllWithSpec([FromQuery]UserSpecParams userParams)
        {
            var spec = new UserWithDepartmentSpecification(userParams);
            var countSpec = new UserWithDepartmentCountSpecification(userParams);
            var totalItems = await _userRepo.CountAsync(countSpec);

            // var data = await _userRepo.GetListWithSpec(spec);
            
            var data = _mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserToReturnDto>>(await _userRepo.GetListWithSpec(spec));

            // return Ok(await _depRepo.GetListWithSpec(spec));
            return Ok(new Pagination<UserToReturnDto>(userParams.PageIndex, userParams.PageSize, totalItems, data));
        }
    }
}