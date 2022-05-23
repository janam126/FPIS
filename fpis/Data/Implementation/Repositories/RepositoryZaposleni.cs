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
    public class RepositoryZaposleni : IRepositoryZaposleni
    {
        private RestoranContext context;

        public RepositoryZaposleni(RestoranContext context)
        {
            this.context = context;
        }

        public Task<bool> Add(Zaposleni entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Zaposleni entity)
        {
            throw new NotImplementedException();
        }

        public Task<Zaposleni> FindByID(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Zaposleni>> GetAll()
        {
            var zaposleni = await context.Zaposleni.ToListAsync();
            return zaposleni;
        }

        public Task<Zaposleni> GetLast()
        {
            throw new NotImplementedException();
        }

        public void Update(Zaposleni entity)
        {
            throw new NotImplementedException();
        }
    }
}
