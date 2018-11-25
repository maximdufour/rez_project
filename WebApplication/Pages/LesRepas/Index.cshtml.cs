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
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public IndexModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        public IList<Repas> Repas { get;set; }

        public async Task OnGetAsync()
        {
            Repas = await _context.Repas
                .Include(r => r.AssistantNavigation)
                .Include(r => r.CookNavigation)
                .Include(r => r.Repas1Navigation)
                .Include(r => r.VaissaileuxNavigation).ToListAsync();
        }
    }
}
