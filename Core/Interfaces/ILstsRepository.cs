using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ILstsRepository
    {
         Task<List<LstDog>> GetBreadCrambForList(Guid id); 
         Task<List<User>> GetAccessUserForList(Guid id);
    }
}