using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class LstsRepository : ILstsRepository
    {
        private readonly IDatabase _database;
        private readonly StoreContext _context;
        public LstsRepository(IConnectionMultiplexer redis, StoreContext context)
        {
           _database = redis.GetDatabase(); 
           _context = context;
        }

        public async Task<List<User>> GetAccessUserForList(Guid id)
        {
            var lstUsers = new List<User>();
            var currentLst = await _context.LstDogs
                .Include(x => x.Departments)
                    .ThenInclude(x => x.Users)
                .FirstOrDefaultAsync(x => x.Id == id);

            while (currentLst != null)
            {
                foreach (var department in currentLst.Departments)
                {
                    foreach (var user in department.Users)
                    {
                        lstUsers.Add(user);
                    }
                }
                // lstDogs.Add(currentLst);
                currentLst = await _context.LstDogs
                    .Include(x => x.Departments)
                        .ThenInclude(x => x.Users)
                    .FirstOrDefaultAsync(x => x.Id == currentLst.ParentId);
            }
            

            return lstUsers;
        }

        public async Task<List<LstDog>> GetBreadCrambForList(Guid id)
        {
            var lstDogs = new List<LstDog>();
            var currentLst = await _context.LstDogs.FirstOrDefaultAsync(x => x.Id == id);

            while (currentLst != null)
            {
                lstDogs.Add(currentLst);
                currentLst = await _context.LstDogs.FirstOrDefaultAsync(x => x.Id == currentLst.ParentId);
            }
            

            return lstDogs;

        }

        
    }
}