using Data.Implementation.Repositories;
using Domen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Interfaces
{
    public interface IRepositoryUsluga : IRepository<Usluga>
    {
        Task<Usluga> FindByName(string name);
    }
}
