using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChinsayVegteables.Context;
using ChinsayVegteables.models;

namespace ChinsayVegteables
{
    public class EditModel : PageModel
    {
        private readonly ChinsayVegteables.Context.VegetablesContext _context;

        public EditModel(ChinsayVegteables.Context.VegetablesContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VegeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VegeDetailsExists(VegeDetails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VegeDetailsExists(long id)
        {
            return _context.VegeDetails.Any(e => e.Id == id);
        }
    }
}
