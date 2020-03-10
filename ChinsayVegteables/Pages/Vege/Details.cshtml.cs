using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChinsayVegteables.Context;
using ChinsayVegteables.models;

namespace ChinsayVegteables
{
    public class DetailsModel : PageModel
    {
        private readonly ChinsayVegteables.Context.VegetablesContext _context;

        public DetailsModel(ChinsayVegteables.Context.VegetablesContext context)
        {
            _context = context;
        }

        public VegeDetails VegeDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VegeDetails = await _context.VegeDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (VegeDetails == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
