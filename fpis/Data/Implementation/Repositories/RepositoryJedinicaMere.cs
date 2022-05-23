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
    public class RepositoryJedinicaMere : IRepositoryJedinicaMere
    {
        private RestoranContext context;

        public RepositoryJedinicaMere(RestoranContext context)
        {
            this.context = context;
        }

        public Task<bool> Add(JedinicaMere entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(JedinicaMere entity)
        {
            throw new NotImplementedException();
        }

        public Task<JedinicaMere> FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JedinicaMere>> GetAll()
        {
            var jedinicaMere = await context.JediniceMere.ToListAsync();
            return jedinicaMere;
        }

        public Task<JedinicaMere> GetLast()
        {
            throw new NotImplementedException();
        }

        public void Update(JedinicaMere entity)
        {
            throw new NotImplementedException();
        }
    }
}
