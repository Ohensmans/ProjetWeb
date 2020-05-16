using ModelesApi.POC;
using System.Collections.Generic;

namespace CoronaOutWeb.ViewModel
{
    public class RegisterViewModel
    {
        public Utilisateur User { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public List<string> lGenres;
    }
}
