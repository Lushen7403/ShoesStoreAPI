﻿using System.Linq.Expressions;

namespace ShoesStoreAPI.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int pageSize = 3,
            int pageNumber = 1);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task CreatAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}
