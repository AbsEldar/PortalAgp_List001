using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specification;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<T> GetEntityAsync(Guid id);
        Task<IReadOnlyList<T>> GetListAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetListWithSpec(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}