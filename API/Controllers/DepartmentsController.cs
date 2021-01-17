using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.Department;
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
    // [ApiController]
    // [Route("api/[controller]")]
    public class DepartmentsController : BaseApiController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Department> _depRepo;
        public DepartmentsController(IMapper mapper, IGenericRepository<Department> depRepo)
        {
            _mapper = mapper;
            _depRepo = depRepo;
        }


        [HttpGet("getAllDepDtos")]
        public async Task<ActionResult<IReadOnlyList<DepartmentToReturnDto>>> GetAllDepsDto()
        {
            var spec = new DepsDtoForList();
            var deps = await _depRepo.GetListWithSpec(spec);
            var data = _mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentToReturnDto>>(deps);
            return Ok(data);
        }

        [HttpGet("getAllWithSpec")]
        public async Task<ActionResult<Pagination<DepartmentToReturnDto>>> GetAllWithSpec([FromQuery]DepartmentSpecParams departmentParams)
        {
            var spec = new DepartmentWithUsersSpecification(departmentParams);
            var countSpec = new DepartmentWithUsersCountSpecification(departmentParams);
            var totalItems = await _depRepo.CountAsync(countSpec);

            var deps = await _depRepo.GetListWithSpec(spec);
            var data = _mapper.Map<IReadOnlyList<Department>, IReadOnlyList<DepartmentToReturnDto>>(deps);
            // var data = await _depRepo.GetListWithSpec(spec);


            // return Ok(await _depRepo.GetListWithSpec(spec));
            return Ok(new Pagination<DepartmentToReturnDto>(departmentParams.PageIndex, departmentParams.PageSize, totalItems, data));
        }

        [HttpGet("getDepWithSpec/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetDepWithSpec(Guid id)
        {
            var spec = new DepartmentWithUsersSpecification(id);
            var dep = await _depRepo.GetEntityWithSpec(spec);
            if(dep == null) return NotFound(new ApiResponse(404));
            return Ok(dep);
        }
    }
}