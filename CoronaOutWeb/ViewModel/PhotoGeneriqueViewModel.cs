using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaOutWeb.ViewModel
{
    public class PhotoGeneriqueViewModel
    {
        public PhotoGeneriqueViewModel()
        {
            this.id = Guid.NewGuid();
        }

        public IFormFile Photo{ get; set; }

        public Guid id { get; set; }

    }
}
