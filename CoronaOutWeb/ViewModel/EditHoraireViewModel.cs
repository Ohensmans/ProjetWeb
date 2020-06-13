using ModelesApi.POC;
using System;
using System.Collections.Generic;

namespace CoronaOutWeb.ViewModel
{
    public class EditHoraireViewModel
    {
        public EditHoraireViewModel()
        {
            lHoraire = new List<Horaire>();
            lJours = new JoursSemaine().lJours;
        }

        public List<Horaire> lHoraire { get; set; }

        public Guid EtablissementId { get; set; }

        public List<string> lJours { get; set; }
    }
}
