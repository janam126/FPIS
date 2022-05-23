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
    public class RepositoryUsluga : IRepositoryUsluga
    {
        private RestoranContext context;

        public RepositoryUsluga(RestoranContext context)
        {
            this.context = context;
        }
        public async Task<bool> Add(Usluga usluga)
        {
            usluga.JedinicaMere = context.JediniceMere.Find(usluga.JedinicaMere.SifraJM);
            await context.Usluge.AddAsync(usluga);
            return true;
        }

        public void Delete(Usluga usluga)
        {
            context.Usluge.Remove(usluga);
        }

        public async Task<Usluga> FindByID(int ID)
        {
            return await context.Usluge.Include(usluga => usluga.JedinicaMere).FirstOrDefaultAsync(usluga => usluga.UslugaID == ID);
        }

        public async Task<Usluga> FindByName(string name)
        {
            return await context.Usluge.Include(usluga => usluga.JedinicaMere).FirstOrDefaultAsync(usluga => usluga.NazivUsluge.Contains(name));
        }

        public async Task<List<Usluga>> GetAll()
        {
            return await context.Usluge.ToListAsync();
        }

        public async Task<Usluga> GetLast()
        {
            return await context.Usluge.OrderBy(i => i.UslugaID).LastAsync();
        }

        public void Update(Usluga usluga)
        {
            usluga.JedinicaMere = context.JediniceMere.Find(usluga.JedinicaMere.SifraJM);
            context.Usluge.Update(usluga);
        }
    }
}
