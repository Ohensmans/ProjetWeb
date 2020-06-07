using System;


namespace ModelesApi.POC
{
    public class News
    {

        public News()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Titre { get; set; }

        public string Message { get; set; }

        public bool estAffichePremier { get; set; }

        public string PublieParUserId { get; set; }

        public DateTime DatePublication { get; set; }

        public string ImageName { get; set; } 

    }
}
