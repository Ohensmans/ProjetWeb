using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelesApi.POC;

namespace IdentityServerAspNetIdentity.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<Utilisateur> userManager;
        private readonly SignInManager<Utilisateur> signInManager;

        public UserController(UserManager<Utilisateur> userManager, SignInManager<Utilisateur> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<Utilisateur>> GetUser()
        {
            return userManager.Users.ToList();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Utilisateur>> GetUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Utilisateur user)
        {
                Utilisateur utilisateur = await userManager.FindByIdAsync(user.Id);
                utilisateur.Nom = user.Nom;
                utilisateur.Prenom = user.Prenom;
                utilisateur.Sexe = user.Sexe;
                utilisateur.PhoneNumber = user.PhoneNumber;
                utilisateur.DateNaissance = user.DateNaissance;
                utilisateur.estProfessionel = user.estProfessionel;

                var result = await userManager.UpdateAsync(utilisateur);
            
            if (!result.Succeeded)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }              
            }
            return NoContent();
        }

        // POST: api/Etablissements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Utilisateur>> PostUser(Utilisateur user, string password)
        {
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            else
            return BadRequest();
        }

        // DELETE: api/Etablissements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Utilisateur>> DeleteUser(Utilisateur user)
        {

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        private bool UserExists(string id)
        {
            return userManager.Users.Any(u => u.Id == id);
        }
    }
}
}