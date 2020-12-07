using Databasae.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.EntityService.Interface
{
    public interface IDepartmentService
    {
        Task Create( DepartmentViewModel departmentViewModel );
        Task<DepartmentViewModel> Delete( int? id );
        Task DeleteConfirmed( int id );
        bool DepartmentExists( int id );
        Task<DepartmentViewModel> Details( int? id );
        Task<DepartmentViewModel> Edit( int? id );
        Task Edit( DepartmentViewModel department );
        Task<List<DepartmentViewModel>> Index();
    }
}