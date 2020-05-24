using ModelesApi.POC;
using Repo.Contexts;
using System;
using System.Transactions;

namespace Api
{
    public class SeedData
    {
        private readonly EtablissementContext etbCtx;
        private readonly NewsContext newsCtx;

        public SeedData(EtablissementContext EtbCtx, NewsContext NewsCtx)
        {
            etbCtx = EtbCtx;
            newsCtx = NewsCtx;
        }

        public void SeedHoraires()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                etbCtx.Horaires.Add(new Horaire
                {


                });
             }

        }

        public void SeedEtablissements()
        {

            using (TransactionScope scope = new TransactionScope())
            {
                etbCtx.Etablissements.Add(new Etablissement
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
                    PublieParUserId = Guid.Parse("4d0a2640-3ad9-4c3e-90bd-6cea9825acc2")
                });

                etbCtx.Etablissements.Add(new Etablissement
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
                    PublieParUserId = Guid.Parse("4d0a2640-3ad9-4c3e-90bd-6cea9825acc2")
                });

                etbCtx.SaveChanges();
            }

        }



    }


}
