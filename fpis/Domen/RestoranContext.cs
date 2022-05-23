using Domen.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class RestoranContext : DbContext
    {
        public DbSet<Usluga> Usluge { get; set; }
        public DbSet<JedinicaMere> JediniceMere { get; set; }
        public DbSet<Restoran> Restoran { get; set; }
        public DbSet<Zaposleni> Zaposleni { get; set; }
        public DbSet<StavkaIzvestaja> StavkaIzvestaja { get; set; }
        public DbSet<IzvestajOBrojuDorucaka> IzvestajOBrojuDorucaka { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FPIS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JedinicaMere>().HasKey(e => e.SifraJM);
            modelBuilder.Entity<IzvestajOBrojuDorucaka>().HasKey(e => e.RBIzvestaja);
            modelBuilder.Entity<IzvestajOBrojuDorucaka>().HasMany(e => e.StavkeIzvestaja)
                                                         .WithOne(e => e.IzvestajOBrojuDorucaka);
            modelBuilder.Entity<StavkaIzvestaja>().HasKey(e => new { e.RBStavke, e.IzvestajOBrojuDorucakaID });

        }
    } 
}
