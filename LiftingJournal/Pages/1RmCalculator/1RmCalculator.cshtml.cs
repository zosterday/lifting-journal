using LiftingJournal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LiftingJournal.Pages._1RmCalculator
{
    public class _1RmCalculatorModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (Request.Method != "POST")
            {
                return;
            }

            var weight = Request.Form["weight"];
            var reps = Request.Form["reps"];

            if (!string.IsNullOrEmpty(weight) && !string.IsNullOrEmpty(reps))
            {
                var oneRepMax = Math.Round(double.Parse(weight) * (1 + double.Parse(reps) / 30), 2);
                ViewData[ApiConstants.OneRepMax] = $"Your 1RM is {oneRepMax} lbs.";
            }
        }
    }
}
