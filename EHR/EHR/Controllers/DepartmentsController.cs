using Databasae.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.EntityService.Interface;
using System.Threading.Tasks;

namespace EHR.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentService _departmentService;


        public DepartmentsController( IDepartmentService departmentService )
        {
            _departmentService = departmentService;

        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.Index());
        }

        public async Task<IActionResult> Details( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentViewmodel = await _departmentService.Details(id);

            if (departmentViewmodel == null)
            {
                return NotFound();
            }

            return View(departmentViewmodel);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( [Bind("DepartmentId,DepartmentName")] DepartmentViewModel departmentViewModel )
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Create(departmentViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(departmentViewModel);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var departmentViewModel = await _departmentService.Edit(id);
            if (departmentViewModel == null)
            {
                return NotFound();
            }
            return View(departmentViewModel);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( int id, DepartmentViewModel departmentViewModel )
        {
            if (id != departmentViewModel.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.Edit(departmentViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(departmentViewModel.DepartmentId))
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
            return View(departmentViewModel);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete( int? id )
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.Delete(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed( int id )
        {
            await _departmentService.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists( int id )
        {
            return _departmentService.DepartmentExists(id);
        }
    }
}
