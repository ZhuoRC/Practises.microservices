#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Data;
using MyMicroservice.Models;

namespace MyMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiSamplesController : ControllerBase
    {
        private readonly MyMicroserviceContext _context;

        public ApiSamplesController(MyMicroserviceContext context)
        {
            _context = context;
        }

        // GET: api/ApiSamples
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sample>>> GetSamples()
        {
            return await _context.Samples.ToListAsync();
        }

        // GET: api/ApiSamples/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sample>> GetSample(int id)
        {
            var sample = await _context.Samples.FindAsync(id);

            if (sample == null)
            {
                return NotFound();
            }

            return sample;
        }

        // PUT: api/ApiSamples/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSample(int id, Sample sample)
        {
            if (id != sample.Id)
            {
                return BadRequest();
            }

            _context.Entry(sample).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleExists(id))
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

        // POST: api/ApiSamples
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sample>> PostSample(Sample sample)
        {
            _context.Samples.Add(sample);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSample", new { id = sample.Id }, sample);
        }

        // DELETE: api/ApiSamples/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSample(int id)
        {
            var sample = await _context.Samples.FindAsync(id);
            if (sample == null)
            {
                return NotFound();
            }

            _context.Samples.Remove(sample);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SampleExists(int id)
        {
            return _context.Samples.Any(e => e.Id == id);
        }
    }
}
