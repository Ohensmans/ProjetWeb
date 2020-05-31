using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.Models
{
    public class BaseUrl
    {
        public string ApiEtablissement { get; set; }
        public string ApiHoraire { get; set; }
        public string ApiPhoto { get; set; }

        public string ApiNews { get; set; }

        public string VAT { get; set; }

        public string CoronaOutWeb { get; set; }

        public string IdentityRegister { get; set; }

        public string IdentityMonCompte { get; set; }
        public string IdentityAdmin { get; set; }
    }
}
