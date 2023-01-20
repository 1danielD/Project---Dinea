using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Corporations
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public DeleteModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Corporation Corporation { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Corporation == null)
            {
                return NotFound();
            }

            var corporation = await _context.Corporation.FirstOrDefaultAsync(m => m.ID == id);

            if (corporation == null)
            {
                return NotFound();
            }
            else 
            {
                Corporation = corporation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Corporation == null)
            {
                return NotFound();
            }
            var corporation = await _context.Corporation.FindAsync(id);

            if (corporation != null)
            {
                Corporation = corporation;
                _context.Corporation.Remove(Corporation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
