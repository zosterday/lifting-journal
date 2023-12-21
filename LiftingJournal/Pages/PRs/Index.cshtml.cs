using LiftingJournal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LiftingJournal.Pages.PRs
{
    public class IndexModel : PageModel
    {
        private readonly LiftingJournal.Data.LiftingJournalContext _context;

        public LiftType? LiftTypeFilter { get; set; }

        public int? PR { get; set; }

        public bool IsNoLiftSelected { get; set; } = false;

        public bool HasLiftLogs { get; set; } = true;

        public IndexModel(LiftingJournal.Data.LiftingJournalContext context)
        {
            _context = context;
        }

        public void OnGet(LiftType? liftTypeFilter)
        {
            if (liftTypeFilter is null)
            {
                IsNoLiftSelected = true;
                return;
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ApiConstants.ClaimsNameIdentifier)?.Value;

            IQueryable<Lift> query = _context.Lift;
            query = query.Where(lift => lift.ClientId == userId);

            if (liftTypeFilter != null)
            {
                LiftTypeFilter = liftTypeFilter;
                query = query.Where(lift => lift.LiftType == liftTypeFilter);
            }

            if (query.Count() == 0)
            {
                HasLiftLogs = false;
                return;
            }

            PR = query.Max(lift => lift.Weight);
        }
    }
}
