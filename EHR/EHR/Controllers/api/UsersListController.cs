using EHR.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EHR.Controllers.api
{

    [Produces("application/json")]
    [Route("api/UsersList")]
    [ApiController]
    public class UsersListController : ControllerBase
    {
        private readonly EHRContext _context;
        private readonly IConfiguration configuration;

        public UsersListController( EHRContext context, IConfiguration config )
        {
            _context = context;
            configuration = config;

        }


        // GET: api/UsersList
        [HttpGet]
        public async Task<IActionResult> userlist()
        {
            ////JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            //var query = @"select Stateid from States";
            //var dt = new DataTable();
            //using (var con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            //using (var cmd = new SqlCommand(query, con))
            //using (var da = new SqlDataAdapter(cmd))
            //{
            //    cmd.CommandType = CommandType.Text;
            //    da.Fill(dt);

            //}

            var userlist = await _context.States.Select(x => new { x.StateName }).ToListAsync();
            //return new JsonResult(dt, jsonSerializerSettings);
            //return Ok(new { dt });
            return Ok(new { userlist });
        }

        //// GET: api/UsersList/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AspNetUsers>> GetAspNetUsers( string id )
        //{
        //    var aspNetUsers = await _context.AspNetUsers.FindAsync(id);

        //    if (aspNetUsers == null)
        //    {
        //        return NotFound();
        //    }

        //    return aspNetUsers;
        //}

        //// PUT: api/UsersList/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAspNetUsers( string id, AspNetUsers aspNetUsers )
        //{
        //    if (id != aspNetUsers.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(aspNetUsers).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AspNetUsersExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/UsersList
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<AspNetUsers>> PostAspNetUsers( AspNetUsers aspNetUsers )
        //{
        //    _context.AspNetUsers.Add(aspNetUsers);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (AspNetUsersExists(aspNetUsers.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetAspNetUsers", new { id = aspNetUsers.Id }, aspNetUsers);
        //}

        //// DELETE: api/UsersList/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<AspNetUsers>> DeleteAspNetUsers( string id )
        //{
        //    var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
        //    if (aspNetUsers == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AspNetUsers.Remove(aspNetUsers);
        //    await _context.SaveChangesAsync();

        //    return aspNetUsers;
        //}

        //private bool AspNetUsersExists( string id )
        //{
        //    return _context.AspNetUsers.Any(e => e.Id == id);
        //}
    }
}
