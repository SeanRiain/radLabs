using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class FluentUsersController : Controller
    {
        private readonly FluentUserDbContext _context;

        public FluentUsersController(FluentUserDbContext context)
        {
            _context = context;
        }

        // GET: FluentUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.FluentUsers.ToListAsync());
        }

        // GET: FluentUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentUser = await _context.FluentUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fluentUser == null)
            {
                return NotFound();
            }

            return View(fluentUser);
        }

        // GET: FluentUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FluentUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,title,Biography,Age")] FluentUser fluentUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fluentUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fluentUser);
        }

        // GET: FluentUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentUser = await _context.FluentUsers.FindAsync(id);
            if (fluentUser == null)
            {
                return NotFound();
            }
            return View(fluentUser);
        }

        // POST: FluentUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,title,Biography,Age")] FluentUser fluentUser)
        {
            if (id != fluentUser.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fluentUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FluentUserExists(fluentUser.ID))
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
            return View(fluentUser);
        }

        // GET: FluentUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fluentUser = await _context.FluentUsers
                .FirstOrDefaultAsync(m => m.ID == id);
            if (fluentUser == null)
            {
                return NotFound();
            }

            return View(fluentUser);
        }

        // POST: FluentUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fluentUser = await _context.FluentUsers.FindAsync(id);
            if (fluentUser != null)
            {
                _context.FluentUsers.Remove(fluentUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FluentUserExists(int id)
        {
            return _context.FluentUsers.Any(e => e.ID == id);
        }
    }
}
