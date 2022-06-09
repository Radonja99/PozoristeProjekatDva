using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Rezervacija
    {
   
        public Guid RezervacijaID { get; set; }

        public DateTime DatumKreiranjaRezervacije { get; set; }

        public bool placeno { get; set; }
        public DateTime DatumIstekaRezervacije { get; set; }
        public Guid? KorisnikID { get; set; }

        public Korisnik Korisnik { get; set; }

        public Guid? SedisteID { get; set; }
        public Sediste Sediste { get; set; }

        public Guid? IzvedbaID { get; set; }
        public Izvedba Izvedba { get; set; }
    }
}
