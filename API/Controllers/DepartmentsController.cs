using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Errors;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController: ControllerBase
    {
        private readonly IGenericRepository<Department> _depRepo;
        public DepartmentsController(IGenericRepository<Department> depRepo)
        {
            _depRepo = depRepo;
        }

        [HttpGet("getAllWithSpec")]
        public async Task<ActionResult<Pagination<Department>>> GetAllWithSpec([FromQuery]DepartmentSpecParams departmentParams)
        {
            var spec = new DepartmentWithUsersSpecification(departmentParams);
            var countSpec = new DepartmentWithUsersCountSpecification(departmentParams);
            var totalItems = await _depRepo.CountAsync(countSpec);

            var data = await _depRepo.GetListWithSpec(spec);
            


            // return Ok(await _depRepo.GetListWithSpec(spec));
            return Ok(new Pagination<Department>(departmentParams.PageIndex, departmentParams.PageSize, totalItems, data));
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