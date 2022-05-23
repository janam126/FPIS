using Data.Implementation.Interfaces;
using Domen;
using Domen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation.Repositories
{
    public class RepositoryRestoran : IRepositoryRestoran
    {
        private RestoranContext context;

        public RepositoryRestoran(RestoranContext context)
        {
            this.context = context;
        }

        public Task<bool> Add(Restoran entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Restoran entity)
        {
            throw new NotImplementedException();
        }

        public Task<Restoran> FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Restoran>> GetAll()
        {
            var restoran = await context.Restoran.ToListAsync();
            return restoran;
        }

        public Task<Restoran> GetLast()
        {
            throw new NotImplementedException();
        }

        public void Update(Restoran entity)
        {
            throw new NotImplementedException();
        }
    }
}
