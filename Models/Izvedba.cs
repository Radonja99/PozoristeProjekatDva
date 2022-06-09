using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models
{
    public class Izvedba
    {

      
        public Guid IzvedbaID { get; set; }


        public DateTime DatumPrikazivanja { get; set; }

        public Boolean GostujucaPredstava { get; set; }

        public Guid? SalaID { get; set; }

        public Sala Sala { get; set; }
        public Guid? PredstavaID { get; set; }

        public Predstava Predstava { get; set; }
    }
}
