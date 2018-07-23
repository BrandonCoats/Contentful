using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contentful.Models;

namespace Contentful.Controllers
{
    public class CampaignTypesController : Controller
    {
        private readonly ContentManagerContext _context;

        public CampaignTypesController(ContentManagerContext context)
        {
            _context = context;
        }

        // GET: CampaignTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CampaignType.ToListAsync());
        }

        // GET: CampaignTypes/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignType = await _context.CampaignType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignType == null)
            {
                return NotFound();
            }

            return View(campaignType);
        }

        // GET: CampaignTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CampaignTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CampaignType1")] CampaignType campaignType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campaignType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaignType);
        }

        // GET: CampaignTypes/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignType = await _context.CampaignType.FindAsync(id);
            if (campaignType == null)
            {
                return NotFound();
            }
            return View(campaignType);
        }

        // POST: CampaignTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Id,CampaignType1")] CampaignType campaignType)
        {
            if (id != campaignType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaignType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignTypeExists(campaignType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campaignType);
        }

        // GET: CampaignTypes/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaignType = await _context.CampaignType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaignType == null)
            {
                return NotFound();
            }

            return View(campaignType);
        }

        // POST: CampaignTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var campaignType = await _context.CampaignType.FindAsync(id);
            _context.CampaignType.Remove(campaignType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignTypeExists(short id)
        {
            return _context.CampaignType.Any(e => e.Id == id);
        }
    }
}
