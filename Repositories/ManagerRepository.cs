using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using isg_crm.Interfaces;
using isg_crm.Data;
using isg_crm.Dtos;
using isg_crm.Models;
using Microsoft.EntityFrameworkCore;
using isg_crm.Interfaces;
using BCrypt.Net;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace isg_crm.Repositories
{
    public class ManagerRepository : IManagerInterface
    {
        private readonly AppDbContext _context;

        public ManagerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateManagerAsync(Guid managerId, CreateManagerDto createManagerDto)
        {
            var manager = new Manager
            {
                Email = createManagerDto.Email,
                Name = createManagerDto.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(createManagerDto.Password),
                Type = createManagerDto.Type
            };
            await _context.Managers.AddAsync(manager);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _context.Managers.AnyAsync(u => u.Email == email);
        }

        public async Task<Manager> GetUserByEmailAsync(string email)
        {
            return await _context.Managers.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}