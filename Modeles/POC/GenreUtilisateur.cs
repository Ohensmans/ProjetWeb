using System.Collections.Generic;


namespace ModelesApi.POC
{
    public class GenreUtilisateur
    {
        public GenreUtilisateur()
        {
            List<string> _genres = new List<string>();
            _genres.Add("Homme");
            _genres.Add("Femme");
            _genres.Add("Non-Binaire");
            genres = _genres;
        }

        public List<string> genres { get; }
    }
}
