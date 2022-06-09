using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Pozoriste
    {

        public Guid PozoristeID { get; set; }
        public string NazivPozorista { get; set; }
        public string Adresa { get; set; }
        
        public string Grad { get; set; }
        public Guid? UrednikID { get; set; }

        public Urednik Urednik { get; set; }
    }
}
