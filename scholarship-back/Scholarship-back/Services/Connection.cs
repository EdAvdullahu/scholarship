using Microsoft.EntityFrameworkCore;
using Scholarship_back.Data;
using Scholarship_back.Outer.Models;

namespace Scholarship_back.Services
{
    public class Connection
    {
        private readonly DataContext _context;
        public Connection(DataContext context)
        {
            _context = context;
        }
        public void getUsers()
        {
            _context.Users.ToList();
        }
    }
}
