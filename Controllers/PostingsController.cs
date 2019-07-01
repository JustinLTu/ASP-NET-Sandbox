using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZonePostings.Models;

namespace ZonePostings.Controllers
{
    public class PostingsController : Controller
    {
        private readonly PostingContext _context;

        public PostingsController(PostingContext context)
        {
            _context = context;
        }

        // GET: Postings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posting.ToListAsync());
        }

        // GET: Postings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posting = await _context.Posting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posting == null)
            {
                return NotFound();
            }

            return View(posting);
        }

        // GET: Postings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Payout,Risk,Title,Description")] Posting posting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(posting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posting);
        }

        // GET: Postings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posting = await _context.Posting.FindAsync(id);
            if (posting == null)
            {
                return NotFound();
            }
            return View(posting);
        }

        // POST: Postings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Payout,Risk,Title,Description")] Posting posting)
        {
            if (id != posting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostingExists(posting.Id))
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
            return View(posting);
        }

        // GET: Postings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posting = await _context.Posting
                .FirstOrDefaultAsync(m => m.Id == id);
            if (posting == null)
            {
                return NotFound();
            }

            return View(posting);
        }

        // POST: Postings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posting = await _context.Posting.FindAsync(id);
            _context.Posting.Remove(posting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostingExists(int id)
        {
            return _context.Posting.Any(e => e.Id == id);
        }
    }
}
