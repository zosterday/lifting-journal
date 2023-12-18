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

    //TODO: Need to add special valdiation for model. Like all numbers need to be positive and ina a reasonalble range

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
            Lift.ClientId = User.Claims.FirstOrDefault(c => c.Type == ApiConstants.ClaimsNameIdentifier)?.Value;
             if (Lift.Weight < 0)
            {
                ModelState.AddModelError("Lift.Weight", "Weight cannot be less than 0.");
                TempData[ApiConstants.Error] = "Failed to log lift";
            }
            if (Lift.Sets < 0)          {
                ModelState.AddModelError("Lift.Sets", "Sets cannot be less than 0.");
                TempData[ApiConstants.Error] = "Failed to log lift";
            }
            if (Lift.Reps < 0)
            {
                ModelState.AddModelError("Lift.Reps", "Reps cannot be less than 0.");
                TempData[ApiConstants.Error] = "Failed to log lift";
            }

            if (!ModelState.IsValid)
            {
                TempData[ApiConstants.Error] = "Failed to log lift";
                return Page();
            }

            await _context.Lift.AddAsync(Lift);
            await _context.SaveChangesAsync();

            TempData[ApiConstants.Success] = "Lift logged successfully";
            return RedirectToPage("./Index");
        }
    }
}
