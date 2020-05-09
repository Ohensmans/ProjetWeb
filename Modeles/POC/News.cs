using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelesApi.POC
{
    public class News
    {
        [Key]
        public Guid Id { get; set; }

        public string Message { get; set; }

        public bool estValide { get; set; }
    }
}
