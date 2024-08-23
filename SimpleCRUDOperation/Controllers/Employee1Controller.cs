using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SimpleCRUDOperation.Models;

namespace SimpleCRUDOperation.Controllers
{
    public class Employee1Controller : Controller
    {
        private readonly EmployeeDbContext _context;

        public Employee1Controller(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: Employee1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employee1s.ToListAsync());
        }

        // GET: Employee1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Contact,Address,Department")] Employee1 employee1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee1);
        }

        // GET: Employee1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee1 = await _context.Employee1s.FindAsync(id);
            if (employee1 == null)
            {
                return NotFound();
            }
            return View(employee1);
        }

        // POST: Employee1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Contact,Address,Department")] Employee1 employee1)
        {
            if (id != employee1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Employee1Exists(employee1.Id))
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
            return View(employee1);
        }

        // GET: Employee1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee1 = await _context.Employee1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee1 == null)
            {
                return NotFound();
            }

            return View(employee1);
        }

        // POST: Employee1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee1 = await _context.Employee1s.FindAsync(id);
            if (employee1 != null)
            {
                _context.Employee1s.Remove(employee1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Employee1Exists(int id)
        {
            return _context.Employee1s.Any(e => e.Id == id);
        }
    }
}
