using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Corporations
{
    public class EditModel : PageModel
    {
        private readonly Project.Data.ProjectContext _context;

        public EditModel(Project.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Corporation Corporation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Corporation == null)
            {
                return NotFound();
            }

            var corporation =  await _context.Corporation.FirstOrDefaultAsync(m => m.ID == id);
            if (corporation == null)
            {
                return NotFound();
            }
            Corporation = corporation;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Corporation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CorporationExists(Corporation.ID))
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

        private bool CorporationExists(int id)
        {
          return _context.Corporation.Any(e => e.ID == id);
        }
    }
}
