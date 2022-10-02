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
    public class QualificationsController : ControllerBase
    {
        private readonly StaffManagementSystemAPIContext _context;

        public QualificationsController(StaffManagementSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Qualifications
        // Gets list of all Qualification in db
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Qualification>>> GetQualification()
        {
            return await _context.Qualification.ToListAsync();
        }

        // GET: api/Qualifications/5
        // Gets a Get Qualification by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Qualification>> GetQualification(int id)
        {
            var qualification = await _context.Qualification.FindAsync(id);

            if (qualification == null)
            {
                //Return not found if Qualification by id is not found
                return NotFound();
            }

            return qualification;
        }

        
    }
}
