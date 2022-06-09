using PozoristeProjekat.Models;
using PozoristeProjekat.Models.ModelConfirmations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Repositories
{
    public interface IRezervacijaRepository
    {
        public bool SaveChanges();
        List<Rezervacija> GetRezervacija();

        Rezervacija GetRezervacijaById(Guid RezervacijaId);

        RezervacijaConfirmation CreateRezervacija(Rezervacija rezervacija);

        RezervacijaConfirmation UpdateRezervacija(Rezervacija rezervacija);

        void DeleteRezervacija(Guid RezervacijaId);
    }
}
