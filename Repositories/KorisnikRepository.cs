using AutoMapper;
using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public class KorisnikRepository : IKorisnikRepository


    {
        private readonly PozoristeContext context;
        private readonly IMapper mapper;

        public KorisnikRepository(PozoristeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public KorisnikConfirmation CreateKorisnik(Korisnik korisnik)
        {
            var createdEntity = context.Add(korisnik);

            return mapper.Map<KorisnikConfirmation>(createdEntity.Entity);
        }

        public void DeleteKorisnik(Guid KorisnikId)
        {
            var korisnik = GetKorisnikById(KorisnikId);
            context.Remove(korisnik);
        }

        public List<Korisnik> GetKorisnik()
        {
            return context.Korisnik.ToList();
        }

        public Korisnik GetKorisnikById(Guid KorisnikId)
        {
            return context.Korisnik.FirstOrDefault(e => e.KorisnikID == KorisnikId);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }

        public KorisnikConfirmation UpdateKorisnik(Korisnik korisnik)
        {
            
            Korisnik korisniknew = GetKorisnikById(korisnik.KorisnikID);

            korisniknew.KorisnikID = korisnik.KorisnikID;
            korisniknew.KorisnickoIme = korisnik.KorisnickoIme;
            korisniknew.PrezimeKorisnika = korisnik.PrezimeKorisnika;
            korisniknew.ImeKorisnika = korisnik.ImeKorisnika;

            return new KorisnikConfirmation
            {
                KorisnikID = korisnik.KorisnikID,
                ImeKorisnika = korisnik.ImeKorisnika,
                PrezimeKorisnika = korisnik.PrezimeKorisnika,
                KorisnickoIme = korisnik.KorisnickoIme
            };




        }
        public Korisnik GetByKorisnickoIme(string KorisnickoIme)
        {
            return context.Korisnik.FirstOrDefault(e => e.KorisnickoIme == KorisnickoIme);
        }
    }
}
