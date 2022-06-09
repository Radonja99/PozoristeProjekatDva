using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class PozoristeContext : DbContext
    {
        public PozoristeContext(DbContextOptions<PozoristeContext> options) : base(options)
        {

        }
        public DbSet<Pozoriste> Pozoriste { get; set; }

        public DbSet<Izvedba> Izvedba { get; set; }

        public DbSet<Korisnik> Korisnik { get; set; }

        public DbSet<Predstava> Predstava { get; set; }

        public DbSet<Rezervacija> Rezervacija { get; set; }

        public DbSet<Sala> Sala { get; set; }

        public DbSet<Sediste> Sediste { get; set; }

        public DbSet<Urednik> Urednik { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rezervacija>()
                .HasIndex(u => new { u.IzvedbaID, u.SedisteID })
                .IsUnique();
        }
    }
}
