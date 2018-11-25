using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Models;

namespace WebApplication.Pages.LesRepas
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
        ViewData["Assistant"] = new SelectList(_context.Joueurs, "Id", "Mdp");
        ViewData["Cook"] = new SelectList(_context.Joueurs, "Id", "Mdp");
        ViewData["Repas1"] = new SelectList(_context.TypeRepas, "Id", "Nom");
        ViewData["Vaissaileux"] = new SelectList(_context.Joueurs, "Id", "Mdp");
            return Page();
        }

        [BindProperty]
        public Repas Repas { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Repas.Add(Repas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}