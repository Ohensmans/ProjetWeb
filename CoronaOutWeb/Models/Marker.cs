using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.Models
{
    public class Marker
    {

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public string Nom { get; set; }

        public string NomUrl { get; set; }

        public int nbMinAvantFermeture { get; set; }
    }
}
