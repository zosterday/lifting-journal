using System;
using System.ComponentModel.DataAnnotations;

namespace LiftingJournal.Models
{
    public class Lift
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cannot retrieve valid user id.")]
        public string ClientId { get; set; }

        [Display(Name = "Date Lifted")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateLifted { get; set; }

        [Display(Name = "Lift Type")]
        [Required(ErrorMessage = "Please select a lift type.")]
        public LiftType LiftType { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "The Weight field cannot be negative.")]
        public int Weight { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "The Reps field must be greater than 0.")]
        public int Sets { get; set; } = 1;

        [Range(1, int.MaxValue, ErrorMessage = "The Reps field must be greater than 0.")]
        [Required]
        public int Reps { get; set; } = 1;

    }
}

