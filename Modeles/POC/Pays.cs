using ModelesApi.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelesApi.POC
{
    public class Pays
    {
        [NomPaysAttributeRange()]
        public string Nom { get; set; }
    }
}
