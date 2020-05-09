﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Repo.Contexts;
using System.Linq;

namespace CoronaOutWeb.Controllers
{
    public class EtablissementsController : Controller
    {
        private readonly EtablissementContext _ctx;

        public EtablissementsController(EtablissementContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Detail(string id)
        {
            if (!id.Equals(""))
            {
                using (_ctx)
                {
                    return View (_ctx.Etablissements.FirstOrDefault(x => x.Nom == id));
                }
            }

            return View("Error");
        }




    }
}