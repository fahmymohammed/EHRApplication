using EHR.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EHR.Controllers
{
    public class AdmissionHsController : Controller
    {
        private readonly EHRContext _context;

        public AdmissionHsController( EHRContext context )
        {
            _context = context;
        }

        // GET: AdmissionHs
        public async Task<IActionResult> Index()
        {
            var eHRContext = _context.AdmissionH.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Room);
            return View(await eHRContext.ToListAsync());
        }

        // GET: AdmissionHs/Details/5
        public async Task<IActionResult> Details( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionH = await _context.AdmissionH
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Room)
                .FirstOrDefaultAsync(m => m.AdmissionHid == id);
            if (admissionH == null)
            {
                return NotFound();
            }

            return View(admissionH);
        }

        // GET: AdmissionHs/Create
        public IActionResult Create()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName");
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", null);
            //ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "PatientFirstName");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum");
            return View();
        }

        // POST: AdmissionHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("AdmissionHid,AdmissionDateTime,PatientId,RoomId,DoctorId")] AdmissionH admissionH )
        {
            if (ModelState.IsValid)
            {
                _context.Add(admissionH);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName", admissionH.DoctorId);
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", admissionH.PatientId);
            //ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "PatientFirstName", admissionH.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum", admissionH.RoomId);
            return View(admissionH);
        }

        // GET: AdmissionHs/Edit/5
        public async Task<IActionResult> Edit( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionH = await _context.AdmissionH.Include(a => a.Patient).FirstOrDefaultAsync(m => m.AdmissionHid == id);
            if (admissionH == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName", admissionH.DoctorId);
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", null);
            //ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "PatientFirstName", admissionH.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum", admissionH.RoomId);
            return View(admissionH);
        }

        // POST: AdmissionHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, [Bind("AdmissionHid,AdmissionDateTime,PatientId,RoomId,DoctorId")] AdmissionH admissionH )
        {
            if (id != admissionH.AdmissionHid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admissionH);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdmissionHExists(admissionH.AdmissionHid))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName", admissionH.DoctorId);
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", admissionH.PatientId);
            //ViewData["PatientId"] = new SelectList(_context.Patient, "PatientId", "PatientFirstName", admissionH.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum", admissionH.RoomId);
            return View(admissionH);
        }

        // GET: AdmissionHs/Delete/5
        public async Task<IActionResult> Delete( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var admissionH = await _context.AdmissionH
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Room)
                .FirstOrDefaultAsync(m => m.AdmissionHid == id);
            if (admissionH == null)
            {
                return NotFound();
            }

            return View(admissionH);
        }

        // POST: AdmissionHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( int id )
        {
            var admissionH = await _context.AdmissionH.FindAsync(id);
            _context.AdmissionH.Remove(admissionH);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdmissionHExists( int id )
        {
            return _context.AdmissionH.Any(e => e.AdmissionHid == id);
        }
    }
}
