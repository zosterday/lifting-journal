using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiftingJournal.Data;
using LiftingJournal.Models;

namespace LiftingJournal.Pages.Lifts
{
    public class CreateModel : PageModel
    {
        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public CreateModel(LiftingJournal.Data.LiftingJournalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lift Lift { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Lift.AddAsync(Lift);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
