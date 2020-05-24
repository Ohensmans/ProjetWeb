using ModelesApi.POC;
using System;
using System.Collections.Generic;

namespace Api
{
    public static class Config
    {

        public static IEnumerable<Etablissement> Etablissements =>
             new List<Etablissement>
            {
                 new Etablissement
                {
                    Type = "Bar",
                    Nom = "Galoute",
                    NumeroTva= "0864.519.824",
                    AdresseEmailPro="galoute@galoute.be",
                    CodePostal = "1348",
                    Ville ="Louvain-la-Neuve",
                    Pays ="Belgique",
                    Rue ="Rue Rabelais",
                    NumeroBoite="23",
                    estValide = true,
                    PublieParUserId = Guid.Parse("4d0a2640-3ad9-4c3e-90bd-6cea9825acc2")
                },

                new Etablissement
                {
                    Type = "Bar",
                    Nom = "Les Halles",
                    NumeroTva = "0420.154.609",
                    AdresseEmailPro = "galoute@galoute.be",
                    CodePostal = "1348",
                    Ville = "Louvain-la-Neuve",
                    Pays = "Belgique",
                    Rue = "Rue des Wallons",
                    NumeroBoite = "13",
                    estValide = true,
                    PublieParUserId = Guid.Parse("4d0a2640-3ad9-4c3e-90bd-6cea9825acc2")
                }

            };

    }
}
