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
    public class IndexModel : PageModel
    {
        private readonly ChinsayVegteables.Context.VegetablesContext _context;

        public IndexModel(ChinsayVegteables.Context.VegetablesContext context)
        {
            _context = context;
        }

        public IList<VegeDetails> VegeDetails { get;set; }

        public async Task OnGetAsync()
        {
            VegeDetails = await _context.VegeDetails.ToListAsync();
        }
    }
}
