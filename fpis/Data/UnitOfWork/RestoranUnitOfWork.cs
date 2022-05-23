using Data.Implementation.Interfaces;
using Data.Implementation.Repositories;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class RestoranUnitOfWork : IUnitOfWork, IDisposable
    {
        private RestoranContext context;

        public IRepositoryIzvestaj Izvestaj { get; set; }
        public IRepositoryJedinicaMere JedinicaMere { get; set; }
        public IRepositoryRestoran Restoran { get; set; }
        public IRepositoryUsluga Usluga { get; set; }
        public IRepositoryZaposleni Zaposleni { get; set; }

        public RestoranUnitOfWork(RestoranContext context)
        {
            this.context = context;
            Izvestaj = new RepositoryIzvestaj(context);
            JedinicaMere = new RepositoryJedinicaMere(context);
            Restoran = new RepositoryRestoran(context);
            Usluga = new RepositoryUsluga(context);
            Zaposleni = new RepositoryZaposleni(context);
        }
        public void Commit()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}
