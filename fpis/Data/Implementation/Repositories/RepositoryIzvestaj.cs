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
    public class RepositoryIzvestaj : IRepositoryIzvestaj
    {
        private RestoranContext context;

        public RepositoryIzvestaj(RestoranContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(IzvestajOBrojuDorucaka izvestaj)
        {
            izvestaj.Restoran = context.Restoran.Find(izvestaj.Restoran.RestoranID);
            izvestaj.Zaposleni = context.Zaposleni.Find(izvestaj.Zaposleni.ZaposleniID);
            izvestaj.UkupanBrojDorucaka = izvestaj.StavkeIzvestaja.Sum(stavka => stavka.BrojDorucaka);
            await context.IzvestajOBrojuDorucaka.AddAsync(izvestaj);
            return true;
        }

        public void Delete(IzvestajOBrojuDorucaka izvestaj)
        {
            context.IzvestajOBrojuDorucaka.Remove(izvestaj);
        }

        public async Task<IzvestajOBrojuDorucaka> FindByID(int ID)
        {
            return await context.IzvestajOBrojuDorucaka.Include(izvestaj => izvestaj.StavkeIzvestaja)
                                                       .Include(izvestaj => izvestaj.Restoran)
                                                       .Include(izvestaj => izvestaj.Zaposleni)
                                                       .FirstAsync(izvestaj => izvestaj.RBIzvestaja == ID);
        }

        public async Task<List<IzvestajOBrojuDorucaka>> GetAll()
        {
            return await context.IzvestajOBrojuDorucaka.Include(izvestaj => izvestaj.Restoran).ToListAsync();
        }

        public async Task<IzvestajOBrojuDorucaka> GetLast()
        {
            return await context.IzvestajOBrojuDorucaka.OrderBy(i=>i.RBIzvestaja).LastAsync();
        }

        public void Update(IzvestajOBrojuDorucaka izvestaj)
        {
            var izvestajEntity = context.IzvestajOBrojuDorucaka
                                        .AsNoTracking()
                                        .Include(i => i.StavkeIzvestaja)
                                        .FirstOrDefault(i => i.RBIzvestaja == izvestaj.RBIzvestaja);

            izvestajEntity.StavkeIzvestaja.ForEach(stavka =>
            {
                if (!izvestaj.StavkeIzvestaja.Contains(stavka))
                {
                    context.StavkaIzvestaja.Remove(stavka);
                }
            });
            context.Entry(izvestajEntity).State = EntityState.Detached;

            izvestaj.Restoran = context.Restoran.Find(izvestaj.Restoran.RestoranID);
            izvestaj.Zaposleni = context.Zaposleni.Find(izvestaj.Zaposleni.ZaposleniID);
            
            izvestaj.UkupanBrojDorucaka = izvestaj.StavkeIzvestaja.Sum(stavka => stavka.BrojDorucaka);

            context.IzvestajOBrojuDorucaka.Update(izvestaj);
        }
    }
}
