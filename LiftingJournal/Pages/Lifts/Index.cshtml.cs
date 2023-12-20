using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LiftingJournal.Data;
using LiftingJournal.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace LiftingJournal.Pages.Lifts
{
    public class IndexModel : PageModel
    {
        private const int PageLiftEntryLimit = 15;

        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }

        public LiftType? LiftTypeFilter { get; set; }

        public IndexModel(LiftingJournal.Data.LiftingJournalContext context)
        {
            _context = context;
        }

        public IList<Lift> Lifts { get;set; } = default!;

        public async Task OnGetAsync(int? pageIndex, LiftType? liftTypeFilter)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ApiConstants.ClaimsNameIdentifier)?.Value;

            IQueryable<Lift> query = _context.Lift;
            query = query.Where(lift => lift.ClientId == userId)
                .OrderByDescending(lift => lift.DateLifted);

            if (liftTypeFilter != null)
            {
                LiftTypeFilter = liftTypeFilter;
                query = query.Where(lift => lift.LiftType == liftTypeFilter);
            }

            if (pageIndex == null || pageIndex == 1)
            {
                pageIndex = 1;
            }
            PageIndex = (int)pageIndex;

            decimal liftEntryCount = query.Count();
            TotalPages = (int)Math.Ceiling(liftEntryCount / PageLiftEntryLimit);
            query = query.Skip((PageIndex - 1) * PageLiftEntryLimit)
                .Take(PageLiftEntryLimit);

            Lifts = await query.ToListAsync();
        }
    }
}
