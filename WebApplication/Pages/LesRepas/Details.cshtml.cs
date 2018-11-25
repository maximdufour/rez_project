using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesRepas
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public DetailsModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
