using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementSystem.API.Data;
using StaffManagementSystem.Data.Models;

namespace StaffManagementSystem.API
{
    public class ApplicationLogic
    {
        private readonly ISession _session;
        private StaffManagementSystemAPIContext _context;
        public ApplicationLogic()
        {

        }
        public ApplicationLogic(ISession session, StaffManagementSystemAPIContext context)
        {
            _session = session;
            _context = context;
        }
        public async Task<IEnumerable<Staff>> GetAllStaff()
        {
            return await _context.Staff.ToListAsync();
        }

    }
}
