using ModelesApi.POC;
using System.Collections.Generic;


namespace CoronaOutWeb.ViewModel
{
    public class EditEtablissementViewModel
    {
        public EditEtablissementViewModel()
        {
            lTypeEtablissement = new TypeEtablissement().types;
            lPays = new Pays().lPays;
            lJoursSemaines = new JoursSemaine().lJours;
        }

        public Etablissement Etab { get; set; }

        public List<string> lTypeEtablissement { get; set; }

        public List<string> lPays { get; set; }

        public List<string> lJoursSemaines { get; set; }

    }
}
