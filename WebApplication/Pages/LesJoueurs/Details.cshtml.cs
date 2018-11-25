﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesJoueurs
{
    public class DetailsModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public DetailsModel(WebApplication.Models.masterContext context)
        {
            _context = context;
        }

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
    }
}
