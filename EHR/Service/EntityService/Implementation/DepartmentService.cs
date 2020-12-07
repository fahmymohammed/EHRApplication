using Databasae.Database;
using Databasae.EntityModels;
using Microsoft.EntityFrameworkCore;
using Service.EntityService.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.EntityService.Implementation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly EHRContext _db;


        public DepartmentService( EHRContext db )
        {
            _db = db;
        }

        public async Task<List<DepartmentViewModel>> Index()
        {
            var department = await _db.Department.ToListAsync();
            List<DepartmentViewModel> departmentViewModel = new List<DepartmentViewModel>();
            foreach (var item in department)
            {
                departmentViewModel.Add(new Databasae.EntityModels.DepartmentViewModel()
                {
                    DepartmentId = item.DepartmentId,
                    DepartmentName = item.DepartmentName
                });
            }

            return departmentViewModel;
        }

        public async Task<DepartmentViewModel> Details( int? id )
        {
            var department = await _db.Department
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            var departmentViewModel = new Databasae.EntityModels.DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };

            return departmentViewModel;
        }

        public async Task Create( DepartmentViewModel departmentViewModel )
        {
            var department = new Department
            {
                DepartmentId = departmentViewModel.DepartmentId,
                DepartmentName = departmentViewModel.DepartmentName
            };

            _db.Add(department);
            await _db.SaveChangesAsync();

        }

        public async Task<DepartmentViewModel> Edit( int? id )
        {
            var department = await _db.Department.FindAsync(id);
            var departmentViewModel = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName

            };

            return departmentViewModel;
        }

        public async Task Edit( DepartmentViewModel departmentViewModel )
        {
            var department = _db.Department.Where(x => x.DepartmentId == departmentViewModel.DepartmentId).FirstOrDefault();
            department.DepartmentId = departmentViewModel.DepartmentId;
            department.DepartmentName = departmentViewModel.DepartmentName;

            _db.Update(department);
            await _db.SaveChangesAsync();

        }


        public async Task<DepartmentViewModel> Delete( int? id )
        {


            var department = await _db.Department.FirstOrDefaultAsync(m => m.DepartmentId == id);
            var departmentViewmodel = new DepartmentViewModel
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName
            };
            return departmentViewmodel;
        }

        public async Task DeleteConfirmed( int id )
        {
            var department = await _db.Department.FindAsync(id);
            _db.Department.Remove(department);
            await _db.SaveChangesAsync();
        }


        public bool DepartmentExists( int id )
        {
            return _db.Department.Any(e => e.DepartmentId == id);
        }
    }
}
