﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PozoristeProjekat.Models.ModelConfirmations
{
    public class RezervacijaConfirmation
    {
        public Guid RezervacijaID { get; set; }

        public DateTime DatumKreiranjaRezervacije { get; set; }
    }
}
