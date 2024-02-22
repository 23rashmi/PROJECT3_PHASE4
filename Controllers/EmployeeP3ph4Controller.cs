using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using p3p4.Models;

namespace p3p4.Controllers
{
    public class EmployeeP3ph4Controller : Controller
    {
        private readonly P3P4Context _context;

        public EmployeeP3ph4Controller(P3P4Context context)
        {
            _context = context;
        }

        // GET: EmployeeP3ph4
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeP3ph4s != null ? 
                          View(await _context.EmployeeP3ph4s.ToListAsync()) :
                          Problem("Entity set 'P3P4Context.EmployeeP3ph4s'  is null.");
        }

        // GET: EmployeeP3ph4/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeP3ph4s == null)
            {
                return NotFound();
            }

            var employeeP3ph4 = await _context.EmployeeP3ph4s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeP3ph4 == null)
            {
                return NotFound();
            }

            return View(employeeP3ph4);
        }

        // GET: EmployeeP3ph4/Create
        public IActionResult Create()
        {
            return View(new EmployeeP3ph4());
        }

        // POST: EmployeeP3ph4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Salary")] EmployeeP3ph4 employeeP3ph4)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeP3ph4);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeP3ph4);
        }

        // GET: EmployeeP3ph4/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeP3ph4s == null)
            {
                return NotFound();
            }

            var employeeP3ph4 = await _context.EmployeeP3ph4s.FindAsync(id);
            if (employeeP3ph4 == null)
            {
                return NotFound();
            }
            return View(employeeP3ph4);
        }

        // POST: EmployeeP3ph4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Salary")] EmployeeP3ph4 employeeP3ph4)
        {
            if (id != employeeP3ph4.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeP3ph4);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeP3ph4Exists(employeeP3ph4.Id))
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
            return View(employeeP3ph4);
        }

        // GET: EmployeeP3ph4/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeP3ph4s == null)
            {
                return NotFound();
            }

            var employeeP3ph4 = await _context.EmployeeP3ph4s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeP3ph4 == null)
            {
                return NotFound();
            }

            return View(employeeP3ph4);
        }

        // POST: EmployeeP3ph4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeP3ph4s == null)
            {
                return Problem("Entity set 'P3P4Context.EmployeeP3ph4s'  is null.");
            }
            var employeeP3ph4 = await _context.EmployeeP3ph4s.FindAsync(id);
            if (employeeP3ph4 != null)
            {
                _context.EmployeeP3ph4s.Remove(employeeP3ph4);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeP3ph4Exists(int id)
        {
          return (_context.EmployeeP3ph4s?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
