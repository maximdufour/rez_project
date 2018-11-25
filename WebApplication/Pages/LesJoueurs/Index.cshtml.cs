using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesJoueurs
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public IndexModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

        public IList<Joueurs> Joueurs { get;set; }

        public async Task OnGetAsync()
        {
            Joueurs = await _context.Joueurs.ToListAsync();
        }
    }
}
