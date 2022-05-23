using Data.Implementation.Interfaces;
using System;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepositoryIzvestaj Izvestaj { get; set; }
        public IRepositoryJedinicaMere JedinicaMere { get; set; }
        public IRepositoryRestoran Restoran { get; set; }
        public IRepositoryUsluga Usluga { get; set; }
        public IRepositoryZaposleni Zaposleni { get; set; }
        void Commit();
    }
}
