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
    public class DetailsModel : PageModel
    {
        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public DetailsModel(LiftingJournal.Data.LiftingJournalContext context)
        {
            _context = context;
        }

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
    }
}
