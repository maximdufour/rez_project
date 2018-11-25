using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesJoueurs
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public EditModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Joueurs Joueurs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Joueurs = await _context.Joueurs.FirstOrDefaultAsync(m => m.Id == id);

            if (Joueurs == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Joueurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JoueursExists(Joueurs.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JoueursExists(int id)
        {
            return _context.Joueurs.Any(e => e.Id == id);
        }
    }
}
