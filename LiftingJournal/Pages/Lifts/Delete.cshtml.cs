using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiftingJournal.Data;
using LiftingJournal.Models;

namespace LiftingJournal.Pages.Lifts
{
    public class DeleteModel : PageModel
    {
        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public DeleteModel(LiftingJournal.Data.LiftingJournalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lift Lift { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lift = await _context.Lift.FirstOrDefaultAsync(m => m.Id == id);

            if (lift == null)
            {
                return NotFound();
            }
            else
            {
                Lift = lift;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lift = await _context.Lift.FindAsync(id);
            if (lift != null)
            {
                Lift = lift;
                _context.Lift.Remove(Lift);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
