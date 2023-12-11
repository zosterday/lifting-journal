using System;
using System.ComponentModel.DataAnnotations;

namespace LiftingJournal.Models
{
    public class Lift
    {
        public int Id { get; set; }

        public string ClientId { get; private set; }

        [Display(Name = "Date Lifted")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateLifted { get; set; }

        [Display(Name = "Lift Type")]
        [Required]
        public LiftType LiftType { get; set; }

        public int Weight { get; set; } = 0;

        public int Sets { get; set; } = 1;

        [Required]
        public int Reps { get; set; }

    }
}

