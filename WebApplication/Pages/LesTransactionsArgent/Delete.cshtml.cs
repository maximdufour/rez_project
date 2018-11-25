using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Pages.LesTransactionsArgent
{
    public class DeleteModel : PageModel
    {
        private readonly WebApplication.Models.masterContext _context;

        public DeleteModel(WebApplication.Models.masterContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TransactionArgent = await _context.TransactionArgent.FindAsync(id);

            if (TransactionArgent != null)
            {
                _context.TransactionArgent.Remove(TransactionArgent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
