﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication.Models;

namespace WebApplication.Pages.LesTypesRepas
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
            return Page();
        }

        [BindProperty]
        public TypeRepas TypeRepas { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TypeRepas.Add(TypeRepas);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}