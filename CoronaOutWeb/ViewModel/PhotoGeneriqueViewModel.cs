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
            this.IsToBeDeleted = false;
        }

        public IFormFile Photo{ get; set; }

        public Guid id { get; set; }

        public string Path { get; set; }

        public bool IsToBeDeleted { get; set; }

    }
}
