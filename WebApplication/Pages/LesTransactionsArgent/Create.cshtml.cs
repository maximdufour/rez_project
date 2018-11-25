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
    public class CreateModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public CreateModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Joueur"] = new SelectList(_context.Joueurs, "Id", "Nom");
            ViewData["Repas"] = new SelectList(_context.Repas.Include(t => t.Repas1Navigation), "Id", "Identity");

            return Page();
        }

        [BindProperty]
        public TransactionArgent TransactionArgent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TransactionArgent.Add(TransactionArgent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}