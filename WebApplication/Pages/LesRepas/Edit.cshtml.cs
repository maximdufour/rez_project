using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesRepas
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public EditModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Repas Repas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Repas = await _context.Repas
                .Include(r => r.AssistantNavigation)
                .Include(r => r.CookNavigation)
                .Include(r => r.Repas1Navigation)
                .Include(r => r.VaissaileuxNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Repas == null)
            {
                return NotFound();
            }
           ViewData["Assistant"] = new SelectList(_context.Joueurs, "Id", "Nom");
           ViewData["Cook"] = new SelectList(_context.Joueurs, "Id", "Nom");
           ViewData["Repas1"] = new SelectList(_context.TypeRepas, "Id", "Nom");
           ViewData["Vaissaileux"] = new SelectList(_context.Joueurs, "Id", "Nom");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Repas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepasExists(Repas.Id))
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

        private bool RepasExists(int id)
        {
            return _context.Repas.Any(e => e.Id == id);
        }
    }
}
