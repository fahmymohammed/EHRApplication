﻿using Databasae.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EHR.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly EHRContext _context;

        public DoctorsController( EHRContext context )
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var eHRContext = _context.Doctor.Include(d => d.Department).Include(d => d.State);
            return View(await eHRContext.ToListAsync());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Department)
                .Include(d => d.State)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("DoctorId,DoctorFirstName,DoctorLastName,DepartmentId,DoctorAddresss,DoctorCity,DoctorZipCode,StateId,Ssn,DoctorMobile,DoctorEmail")] Doctor doctor )
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", doctor.DepartmentId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", doctor.DepartmentId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, [Bind("DoctorId,DoctorFirstName,DoctorLastName,DepartmentId,DoctorAddresss,DoctorCity,DoctorZipCode,StateId,Ssn,DoctorMobile,DoctorEmail")] Doctor doctor )
        {
            if (id != doctor.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.DoctorId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", doctor.DepartmentId);
            ViewData["StateId"] = new SelectList(_context.States, "StateId", "StateName");
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Department)
                .Include(d => d.State)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( int id )
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists( int id )
        {
            return _context.Doctor.Any(e => e.DoctorId == id);
        }
    }
}
