using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesTypesRepas
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public DetailsModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

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
    }
}
