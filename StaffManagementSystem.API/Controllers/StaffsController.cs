using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementSystem.API.Data;
using StaffManagementSystem.Data.Models;

namespace StaffManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly StaffManagementSystemAPIContext _context;
        public StaffsController(StaffManagementSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Staffs
        // Gets a list of staff in the db
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }

        // GET: api/Staffs/EmpNumExists?emp_number=12345678901234567890
        // Returns true if staff with emp_number param is found, else returns false
        [HttpGet]
        [Route("/api/Staffs/EmpNumExists")]

        public async Task<ActionResult<bool>> EmpNumExists(string emp_number)
        {
            var emp_num_exists = await _context.Staff.AnyAsync(e => e.emp_number == emp_number);
            return emp_num_exists;
        }

        // GET: api/Staffs/5
        // Gets staff by emp_number
        [HttpGet("{emp_number}")]
        public async Task<ActionResult<Staff>> GetStaff(string emp_number)
        {
            var staff = await _context.Staff.Include(x => x.gender).Include(x => x.qualification).Where(x=> x.emp_number == emp_number).FirstOrDefaultAsync();

            if (staff == null)
            {
                // If staff not found return not found
                return NotFound();
            }

            // return staff object
            return staff;
        }

        // POST: api/Staffs/UpdateStaff/staff obj
        // Updates staff details
        [HttpPost]
        [Route("/api/Staffs/UpdateStaff")]
        public async Task<IActionResult> UpdateStaff(Staff staff)
        {
            // get staff to update
           var staffTopUpdate= _context.Staff.Where(x => x.Id == staff.Id).FirstOrDefault();

            // check if staff record exists, if not return not found
            if (staffTopUpdate==null)
            {
                return NotFound();
            }
            else
            {
                //set details of staff to be updated with new data 
                staffTopUpdate.first_name=staff.first_name;
                staffTopUpdate.last_name=staff.last_name;

                //_context.Entry(staffTopUpdate).State = EntityState.Detached;
                _context.Entry(staffTopUpdate).State = EntityState.Modified;

                try
                {
                    // Save changes
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // if any error occurs
                    return BadRequest();
                }
            }

            

            return NoContent();
        }

        // POST: api/Staffs
        [HttpPost]
        [Route("/api/Staffs/CreateStaff")]
        public async Task<ActionResult<Staff>> CreateStaff(Staff staff)
        {
            try
            {
                Utility utility = new Utility();
                //Set gender 
                staff.gender = _context.Gender.Where(x => x.Id == staff.gender.Id).FirstOrDefault();
                //Set qualification
                staff.qualification = _context.Qualification.Where(x => x.Id == staff.qualification.Id).FirstOrDefault();
                //calculate salary
                staff.salary = utility.calculateSalary(staff.years_experience, staff.qualification.level);

                //save staff
                _context.Staff.Add(staff);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetStaff", new { id = staff.emp_number }, staff);
            }
            catch
            {
                //Return bad request if any exception is thrown
                //handle proper error by checking exception in future
                return BadRequest();
            }
            
            
        }

        // DELETE: api/Staffs/DeleteStaff/5
        [HttpPost]
        [Route("/api/Staffs/DeleteStaff/{Id}")]
        public async Task<IActionResult> DeleteStaff(int Id)
        {
            //Get staff by Id
            var staff = await _context.Staff.FindAsync(Id);

            //check if staff with Id exists
            if (staff == null)
            {
                //Return not found if staff does not exist
                return NotFound();
            }

            // Delete staff record
            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            //return suceess code
            return NoContent();
        }

      
    }
}
