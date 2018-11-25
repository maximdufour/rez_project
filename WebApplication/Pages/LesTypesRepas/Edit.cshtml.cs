using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesTypesRepas
{
    public class EditModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public EditModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeRepas TypeRepas { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeRepas = await _context.TypeRepas.FirstOrDefaultAsync(m => m.Id == id);

            if (TypeRepas == null)
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

            _context.Attach(TypeRepas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeRepasExists(TypeRepas.Id))
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

        private bool TypeRepasExists(int id)
        {
            return _context.TypeRepas.Any(e => e.Id == id);
        }
    }
}
