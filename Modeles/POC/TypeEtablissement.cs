using System.Collections.Generic;


namespace ModelesApi.POC
{
    public class TypeEtablissement
    {
        public TypeEtablissement()
        {
            List<string> _types = new List<string>();
            _types.Add("Bar");
            _types.Add("Boite de Nuit");
            _types.Add("Salle de Concert");
            _types.Add("Cercle Etudiant");
            types = _types;
        }

        public List<string> types { get; }
    }
}
