using Databasae.Database;
using EHR.Models.viewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service;
using System;
using System.Collections.Generic;
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
            var eHRContext = _context.AdmissionH.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Room).Include(a => a.Insurance);
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
                .Include(a => a.Insurance)
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
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName");
            return View();
        }

        // POST: AdmissionHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("AdmissionHid,AdmissionDateTime,PatientId,RoomId,DoctorId,InsuranceId")] AdmissionH admissionH )
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
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", admissionH.InsuranceId);
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
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", admissionH.InsuranceId);
            return View(admissionH);
        }

        // POST: AdmissionHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, [Bind("AdmissionHid,AdmissionDateTime,PatientId,RoomId,DoctorId,InsuranceId")] AdmissionH admissionH )
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
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", admissionH.InsuranceId);
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
                .Include(a => a.Insurance)
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


        public ActionResult CreateNewAdmission()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName");
            ViewData["PatientId"] = new SelectList((from s in _context.Patient.Where(x => x.IsAdmissioned == false) select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", null);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum");
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName");

            return View();
        }

        public ActionResult CreateNewAdmissionVue()
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName");
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", null);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum");
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName");

            return View();
        }


        [ValidateAntiForgeryToken]
        public ActionResult CreateNewAdmissionPost( [FromForm] admissionviewModel admissionviewmodel )
        {
            if (ModelState.IsValid)
            {

                using (var transaction = _context.Database.BeginTransaction())
                {
                    var admissionH = new AdmissionH
                    {
                        PatientId = admissionviewmodel.PatientId,
                        RoomId = admissionviewmodel.RoomId,
                        DoctorId = admissionviewmodel.DoctorId,
                        AdmissionDateTime = admissionviewmodel.AdmissionDateTime,
                        InsuranceId = admissionviewmodel.InsuranceId,
                        Discharge = false


                    };
                    _context.Add(admissionH);
                    _context.SaveChanges();

                    var PatientInfo = _context.Patient.Where(x => x.PatientId == admissionH.PatientId).FirstOrDefault();
                    PatientInfo.IsAdmissioned = true;

                    _context.Update(PatientInfo);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Json(new { status = true, responseText = "successfully", returnAdmissionHid = admissionH.PatientId });

                }

            }

            ModelState.AddModelError("", "error");
            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName", admissionviewmodel.DoctorId);
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName", admissionviewmodel.PatientId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum", admissionviewmodel.RoomId);
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName", admissionviewmodel.InsuranceId);

            return Json(new { status = false, responseText = "Smething Went Wrong" });

        }


        [HttpGet]
        public ActionResult PatientFollowUp( int id )
        {

            var Patient = _context.Patient.Include(x => x.AdmissionH).Where(x => x.PatientId == id).Include(x => x.Visit).FirstOrDefault();
            var PatientAdmissionH = _context.AdmissionH.Where(x => x.PatientId == Patient.PatientId).Include(x => x.Doctor).Include(x => x.Room).Include(x => x.Insurance).FirstOrDefault();
            var PatientVisit = _context.Visit.Where(x => x.PatientId == Patient.PatientId).Include(x => x.Doctor).Include(x => x.Prescription).ToList();


            //var Patient = _context.AdmissionH
            //    .Include(a => a.Doctor)
            //    .Include(b => b.Room)
            //    .Include(c => c.Patient)
            //    .Include(x => x.Insurance)
            //    .Include(x => x.Patient.Visit)
            //    .Include(x => x.Doctor.Visit)
            //    .Where(f => f.AdmissionHid == id)
            //    .FirstOrDefault();


            var admissionFullviewModel = new admissionFullviewModel();
            admissionFullviewModel.AdmissionHid = id;
            admissionFullviewModel.AdmissionDateTime = PatientAdmissionH.AdmissionDateTime;
            admissionFullviewModel.PatientId = Patient.PatientId;
            admissionFullviewModel.RoomId = PatientAdmissionH.RoomId;
            admissionFullviewModel.DoctorId = PatientAdmissionH.DoctorId;
            admissionFullviewModel.Discharge = PatientAdmissionH.Discharge;
            admissionFullviewModel.InsuranceId = PatientAdmissionH.InsuranceId;
            admissionFullviewModel.PatientFirstName = Patient.PatientFirstName;
            admissionFullviewModel.PatientLastName = Patient.PatientLastName;
            admissionFullviewModel.DoctorFirstName = PatientAdmissionH.Doctor.DoctorFirstName;
            admissionFullviewModel.DoctorLastName = PatientAdmissionH.Doctor.DoctorLastName;
            admissionFullviewModel.RoomNum = PatientAdmissionH.Room.RoomNum;
            admissionFullviewModel.InsuranceName = PatientAdmissionH.Insurance.InsuranceName;
            admissionFullviewModel.IsAdmissioned = Patient.IsAdmissioned;
            admissionFullviewModel.visits = PatientVisit;

            ViewData["DoctorId"] = new SelectList(_context.Doctor, "DoctorId", "DoctorFirstName");
            ViewData["PatientId"] = new SelectList((from s in _context.Patient select new { ID = s.PatientId, FullName = s.PatientFirstName + " " + s.PatientLastName }), "ID", "FullName");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomNum");
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsuranceId", "InsuranceName");
            ViewData["MedicineId"] = new SelectList(_context.Medicine, "MedicineId", "MedicineName");
            //ViewData["VisitId"] = new SelectList(_context.Visit, "VisitId", "VisitDate");
            ViewData["VisitId"] = new SelectList((from s in _context.Visit.Where(x => x.PatientId == Patient.PatientId) select new { ID = s.VisitId, visitDate = s.VisitDate }), "ID", "visitDate");
            //ViewData["RoomId"] = new SelectList((from s in _context.Room.Where(x => x.RoomId != PatientAdmissionH.Room.RoomId) select new { ID = s.RoomId, roomNum = s.RoomNum }), "ID", "roomNum");


            return View(admissionFullviewModel);

        }


        public ActionResult GetPrescriptionInfo( int id )
        {

            var prescription = _context.Prescription.Include(x => x.Medicine).Where(x => x.VisitId == id).ToList();

            List<string> prescriptionData = new List<string>();

            foreach (var item in prescription)
            {
                prescriptionData.Add(item.Medicine.MedicineName);
            }

            return Json(new { status = true, mydata = prescriptionData });

        }

        public ActionResult PatientTransfer( int id, int roomId )
        {

            var patient = _context.AdmissionH.Where(x => x.PatientId == id).SingleOrDefault();

            patient.RoomId = roomId;
            _context.Update(patient);
            _context.SaveChanges();

            return Json(new { status = true });

        }

        [HttpPost]
        public ActionResult PatientNewPrescription( int visitId, int medicineId )
        {

            var newPrescription = Factory.CreatePrescription();

            newPrescription.VisitId = visitId;
            newPrescription.MedicineId = medicineId;
            newPrescription.PrescriptionHdate = DateTime.Now;


            _context.Add(newPrescription);
            _context.SaveChanges();

            return Json(new { status = true });

        }

        [HttpPost]
        public ActionResult PatientDischarge( int id )
        {
            var patientAdmission = _context.AdmissionH.Where(x => x.PatientId == id).SingleOrDefault();
            var patient = _context.Patient.Where(x => x.PatientId == id).SingleOrDefault();

            patientAdmission.Discharge = true;
            patient.IsAdmissioned = false;

            _context.Update(patientAdmission);
            _context.Update(patient);

            _context.SaveChanges();

            return Json(new { status = true });

        }
        [HttpPost]
        public ActionResult newVisit( int id, int docId, DateTime visitDateTime )
        {

            var newVisit = Factory.CreateVisit();

            newVisit.VisitDate = visitDateTime;
            newVisit.DoctorId = docId;
            newVisit.PatientId = id;

            _context.Add(newVisit);

            _context.SaveChanges();

            return Json(new { status = true });

        }

    }
}
