using System.Collections.Generic;


namespace IdentityServer.ViewModel
{
    public class RegisterViewModel : MonCompteViewModel
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public List<string> lGenres { get; set; }

    }
}
