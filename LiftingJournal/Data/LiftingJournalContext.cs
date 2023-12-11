using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiftingJournal.Models;

namespace LiftingJournal.Data
{
    public class LiftingJournalContext : DbContext
    {
        public LiftingJournalContext (DbContextOptions<LiftingJournalContext> options)
            : base(options)
        {
        }

        public DbSet<LiftingJournal.Models.Lift> Lift { get; set; } = default!;
    }
}
