using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChinsayVegteables.Context;
using ChinsayVegteables.models;

namespace ChinsayVegteables
{
    public class CreateModel : PageModel
    {
        private readonly ChinsayVegteables.Context.VegetablesContext _context;

        public CreateModel(ChinsayVegteables.Context.VegetablesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public VegeDetails VegeDetails { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VegeDetails.Add(VegeDetails);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
