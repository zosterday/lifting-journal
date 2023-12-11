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
    public class IndexModel : PageModel
    {
        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public IndexModel(LiftingJournal.Data.LiftingJournalContext context)
        {
            _context = context;
        }

        public IList<Lift> Lift { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Lift = await _context.Lift.ToListAsync();
        }
    }
}
