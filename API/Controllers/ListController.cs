using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Dtos.Lsts;
using API.Dtos.User;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListController: ControllerBase
    {

        private readonly IDatabase _database;
        private readonly IMapper _mapper;

        private readonly ILstsRepository _lstsRepository;
        private readonly IGenericRepository<LstDefault> _lstDefaultRepo;
        private readonly IGenericRepository<LstDog> _lstDogRepo;
        private readonly IGenericRepository<LstOrder> _lstOrderRepo;

        public ListController(
            IConnectionMultiplexer redis,
            IMapper mapper,
            ILstsRepository lstsRepository,
            IGenericRepository<LstDefault> lstDefaultRepo,
            IGenericRepository<LstDog> lstDogRepo, 
            IGenericRepository<LstOrder> lstOrderRepo)
        {
            _database = redis.GetDatabase(); 
            _mapper = mapper;
            _lstsRepository = lstsRepository;
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

        [HttpGet("getAndUpdateList/{id}")]
        public async Task<ActionResult<IReadOnlyList<LstBreadCrambDto>>> GetAndUpdateList(Guid id)
        {
            var lsts = await _lstsRepository.GetBreadCrambForList(id);
            var lstsBc = _mapper.Map<IReadOnlyList<LstDog>, IReadOnlyList<LstBreadCrambDto>>(lsts);

             var created = await _database.StringSetAsync($"lst-bc-{id}", 
                JsonSerializer.Serialize(lstsBc.Reverse()));

            return Ok(lstsBc.Reverse());
        }


        [HttpGet("getBreadCrambForList/{id}")]
        public async Task<ActionResult<IReadOnlyList<LstBreadCrambDto>>> GetBreadCrambForList(Guid id)
        {
            var data = await _database.StringGetAsync($"lst-bc-{id}");
            // var retData = data.IsNullOrEmpty ? await GetAndUpdateList(id) : JsonSerializer.Deserialize<List<LstBreadCrambDto>>(data);
            if(data.IsNullOrEmpty) {
                return await GetAndUpdateList(id);
            } else {
                var retData = JsonSerializer.Deserialize<List<LstBreadCrambDto>>(data);
                return Ok(retData);
            }

            // return Ok(retData);

        }

        [HttpGet("getAndUpdateAccessUsersForList/{id}")]
        public async Task<ActionResult<IReadOnlyList<UserForAccessLstDto>>> GetAndUpdateAccessUsersForList(Guid id)
        {
            var users = await _lstsRepository.GetAccessUserForList(id);
            var usersAccess = _mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserForAccessLstDto>>(users);

             var created = await _database.StringSetAsync($"lst-access-{id}", 
                JsonSerializer.Serialize(usersAccess));

            return Ok(usersAccess);
        }

        [HttpGet("getAccessUsersForList/{id}")]
        public async Task<ActionResult<IReadOnlyList<UserForAccessLstDto>>> GetAccessUsersForList(Guid id)
        {
            var data = await _database.StringGetAsync($"lst-access-{id}");
            
            if(data.IsNullOrEmpty) {
                return await GetAndUpdateAccessUsersForList(id);
            } else {
                var retData = JsonSerializer.Deserialize<List<UserForAccessLstDto>>(data);
                return Ok(retData);
            }
        }


        
    }
}