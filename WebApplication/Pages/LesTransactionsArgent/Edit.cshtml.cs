using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesTransactionsArgent
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public EditModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TransactionArgent TransactionArgent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionArgent = await _context.TransactionArgent
                .Include(t => t.JoueurNavigation)
                .Include(t => t.RepasNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (TransactionArgent == null)
            {
                return NotFound();
            }
           ViewData["Joueur"] = new SelectList(_context.Joueurs, "Id", "Mdp");
           ViewData["Repas"] = new SelectList(_context.Repas, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TransactionArgent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionArgentExists(TransactionArgent.Id))
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

        private bool TransactionArgentExists(int id)
        {
            return _context.TransactionArgent.Any(e => e.Id == id);
        }
    }
}
