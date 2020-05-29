using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelesApi.POC
{
    public class News
    {

        public News()
        {
            this.Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string Message { get; set; }

        public bool estValide { get; set; }

        public string PublieParUserId { get; set; }

        public DateTime DatePublication { get; set; }

    }
}
