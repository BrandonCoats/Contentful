using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Contentful.Models;

namespace Contentful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentManagerController : ControllerBase
    {
        private readonly ContentManagerContext _context;

        public ContentManagerController(ContentManagerContext context)
        {
            _context = context;
        }

        // GET: api/CampaignConfigurations
        [HttpGet]
        public IEnumerable<CampaignConfiguration> GetCampaignConfiguration()
        {
            return _context.CampaignConfiguration;
        }

        // GET: api/CampaignConfigurations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssociatedCampaign([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //Get this working
            var campaignConfiguration = await _context.CampaignConfiguration.FindAsync(id);

            if (campaignConfiguration == null)
            {
                return NotFound();
            }

            return Ok(campaignConfiguration);
        }

        // PUT: api/CampaignConfigurations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaignConfiguration([FromRoute] int id, [FromBody] CampaignConfiguration campaignConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaignConfiguration.Id)
            {
                return BadRequest();
            }

            _context.Entry(campaignConfiguration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignConfigurationExists(id))
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

        // POST: api/CampaignConfigurations
        [HttpPost]
        public async Task<IActionResult> PostCampaignConfiguration([FromBody] CampaignConfiguration campaignConfiguration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CampaignConfiguration.Add(campaignConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampaignConfiguration", new { id = campaignConfiguration.Id }, campaignConfiguration);
        }

        // DELETE: api/CampaignConfigurations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaignConfiguration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var campaignConfiguration = await _context.CampaignConfiguration.FindAsync(id);
            if (campaignConfiguration == null)
            {
                return NotFound();
            }

            _context.CampaignConfiguration.Remove(campaignConfiguration);
            await _context.SaveChangesAsync();

            return Ok(campaignConfiguration);
        }

        private bool CampaignConfigurationExists(int id)
        {
            return _context.CampaignConfiguration.Any(e => e.Id == id);
        }
    }
}