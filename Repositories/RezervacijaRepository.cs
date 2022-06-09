using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public RezervacijaRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public RezervacijaConfirmation CreateRezervacija(Rezervacija rezervacija)
        {
            var createdEntity = context.Add(rezervacija);
            return mapper.Map<RezervacijaConfirmation>(createdEntity.Entity);
        }

        public void DeleteRezervacija(Guid RezervacijaId)
        {
            var rezervacija = GetRezervacijaById(RezervacijaId);
            context.Remove(rezervacija);
        }

        public List<Rezervacija> GetRezervacija()
        {
            return context.Rezervacija.Include(g=>g.Izvedba).Include(g=>g.Korisnik).Include(g=>g.Sediste).ToList();
        }

        public Rezervacija GetRezervacijaById(Guid RezervacijaId)
        {
            return context.Rezervacija.FirstOrDefault(e => e.RezervacijaID == RezervacijaId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public RezervacijaConfirmation UpdateRezervacija(Rezervacija rezervacija)
        {
            Rezervacija rezervacijaold = GetRezervacijaById(rezervacija.RezervacijaID);
            rezervacijaold.RezervacijaID = rezervacija.RezervacijaID;
            rezervacijaold.DatumKreiranjaRezervacije = rezervacija.DatumKreiranjaRezervacije;

            return new RezervacijaConfirmation()
            {
                RezervacijaID = rezervacijaold.RezervacijaID,
                DatumKreiranjaRezervacije = rezervacijaold.DatumKreiranjaRezervacije,
               
                
            };
        }
    }
}
