using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
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
        public async Task<ActionResult<IReadOnlyList<Department>>> GetAllWithSpec()
        {
            var spec = new DepartmentWithUsersSpecification();
            return Ok(await _depRepo.GetListWithSpec(spec));
        }

        [HttpGet("getDepWithSpec/{id}")]
        public async Task<ActionResult<IReadOnlyList<Department>>> GetDepWithSpec(Guid id)
        {
            var spec = new DepartmentWithUsersSpecification(id);
            return Ok(await _depRepo.GetEntityWithSpec(spec));
        }
    }
}