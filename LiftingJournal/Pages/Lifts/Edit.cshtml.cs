using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LiftingJournal.Data;
using LiftingJournal.Models;

namespace LiftingJournal.Pages.Lifts
{
    public class EditModel : PageModel
    {
        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public EditModel(LiftingJournal.Data.LiftingJournalContext context)
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

            var lift =  await _context.Lift.FirstOrDefaultAsync(m => m.Id == id);
            if (lift == null)
            {
                return NotFound();
            }
            Lift = lift;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                TempData[ApiConstants.Error] = "Failed to edit lift entry";
                return Page();
            }

            _context.Attach(Lift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiftExists(Lift.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData[ApiConstants.Success] = "Lift edited successfully";
            return RedirectToPage("./Index");
        }

        private bool LiftExists(int id)
        {
            return _context.Lift.Any(e => e.Id == id);
        }
    }
}
