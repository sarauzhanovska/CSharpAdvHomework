﻿
using TimeTracking.Domain.Models;

namespace TimeTracking.Services.Interfaces
{
    public interface IServiceBase<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        List<T> GetFiltered(Func<T, bool> predicate);
        void Insert(T entity);
        bool Update(T entity);
        void Remove(int id);
        void Seed(List<T> entities);
    }
}
