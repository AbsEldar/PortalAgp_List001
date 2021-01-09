using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos.Lsts;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<LstDefault> _lstDefaultRepo;
        private readonly IGenericRepository<LstDog> _lstDogRepo;
        private readonly IGenericRepository<LstOrder> _lstOrderRepo;

        public ListController(
            IMapper mapper,
            IGenericRepository<LstDefault> lstDefaultRepo,
            IGenericRepository<LstDog> lstDogRepo, 
            IGenericRepository<LstOrder> lstOrderRepo)
        {
            _mapper = mapper;
            _lstDefaultRepo = lstDefaultRepo;
            _lstDogRepo = lstDogRepo;
            _lstOrderRepo = lstOrderRepo;
        }

        [HttpGet("rootdog")]
        public async Task<ActionResult<IReadOnlyList<BaseList>>> GetRoot()
        {
            var specDog = new LstDogParentNullSpecification();
            var dogsRoot = await _lstDogRepo.GetListWithSpec(specDog);

            var specOrder = new LstOrderParentNullSpecification();
            var ordersRoot = await _lstOrderRepo.GetListWithSpec(specOrder);
            
            
            List<BaseList> blist = new List<BaseList>();
            foreach (var dog in dogsRoot)
            {
                blist.Add(dog);
            }

            foreach(var order in ordersRoot) 
            {
                blist.Add(order);
            }

            return Ok(blist);
        }

        [HttpGet("{lstTypeClass}/{id}")]
        public async Task<ActionResult<BaseList>> GetLst(LstTypeClass lstTypeClass, Guid id)
        {

            // var bs = await _lstDefaultRepo.GetEntityAsync(id);
            if(lstTypeClass == LstTypeClass.LstDefault)
            {
                return Ok(await _lstDefaultRepo.GetEntityAsync(id));
            } 
            else if(lstTypeClass == LstTypeClass.LstDog)
            {
                var spec = new LstDogWithChildrenSpecification(id);
                return Ok(await _lstDogRepo.GetEntityWithSpec(spec));
            } 
            else if (lstTypeClass == LstTypeClass.LstOrder)
            {
                return Ok(await _lstOrderRepo.GetEntityAsync(id));
            }
            else { 
                return Ok();
            }
            
        }

        [HttpGet("getLstDog/{id}")]
        public async Task<ActionResult<LstDogToReturnDto>> GetLstDog(Guid id)
        {
            var spec = new LstDogWithChildrenSpecification(id);
            var lstDog = await _lstDogRepo.GetEntityWithSpec(spec);
            var lstDogToReturnDto = _mapper.Map<LstDog, LstDogToReturnDto>(lstDog);
            return Ok(lstDogToReturnDto);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BaseList>>> GetLstDogs()
        {
            return Ok(await _lstDogRepo.GetListAsync());   
        }
    }
}