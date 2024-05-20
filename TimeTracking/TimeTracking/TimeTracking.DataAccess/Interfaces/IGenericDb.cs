using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracking.Domain.Models;

namespace TimeTracking.DataAccess.Interfaces
{
    public interface IGenericDb<T> where T : BaseEntity
    {
        int Add(T entity);
        bool Update(T entity);
        bool RemoveById(int id);
        List<T> GetAll();
        T GetById(int id);
        List<T> FilterBy(Func<T, bool> filterCondition);
    }
}
