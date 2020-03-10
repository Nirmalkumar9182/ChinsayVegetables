using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChinsayVegteables.Context;
using ChinsayVegteables.models;

namespace ChinsayVegteables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegeDetailsController : ControllerBase
    {
        private readonly VegetablesContext _context;

        public VegeDetailsController(VegetablesContext context)
        {
            _context = context;
        }

        // GET: api/VegeDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VegeDetails>>> GetVegeDetails()
        {
            return await _context.VegeDetails.ToListAsync();
        }

        // GET: api/VegeDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VegeDetails>> GetVegeDetails(long id)
        {
            var vegeDetails = await _context.VegeDetails.FindAsync(id);

            if (vegeDetails == null)
            {
                return NotFound();
            }

            return vegeDetails;
        }

        // PUT: api/VegeDetails/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVegeDetails(long id, VegeDetails vegeDetails)
        {
            if (id != vegeDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(vegeDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VegeDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VegeDetails
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<VegeDetails>> PostVegeDetails(VegeDetails vegeDetails)
        {
            _context.VegeDetails.Add(vegeDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVegeDetails", new { id = vegeDetails.Id }, vegeDetails);
        }

        // DELETE: api/VegeDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VegeDetails>> DeleteVegeDetails(long id)
        {
            var vegeDetails = await _context.VegeDetails.FindAsync(id);
            if (vegeDetails == null)
            {
                return NotFound();
            }

            _context.VegeDetails.Remove(vegeDetails);
            await _context.SaveChangesAsync();

            return vegeDetails;
        }

        private bool VegeDetailsExists(long id)
        {
            return _context.VegeDetails.Any(e => e.Id == id);
        }
    }
}
