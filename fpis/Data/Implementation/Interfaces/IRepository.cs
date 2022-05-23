using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Add(T entity);
        void Update(T entity);
        Task<List<T>> GetAll();
        Task<T> FindByID(int ID);
        Task<T> GetLast();
        void Delete(T entity);
    }
}
