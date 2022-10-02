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
    public class GendersController : ControllerBase
    {
        private readonly StaffManagementSystemAPIContext _context;

        public GendersController(StaffManagementSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Genders
        // Gets list of all genders in db
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gender>>> GetGender()
        {
            return await _context.Gender.ToListAsync();
        }

        // GET: api/Genders/5
        // Gets a gender by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Gender>> GetGender(int id)
        {
            var gender = await _context.Gender.FindAsync(id);

            if (gender == null)
            {
                //Return not found if gender by id is not found
                return NotFound();
            }

            // Return genger object
            return gender;
        }

        
    }
}
