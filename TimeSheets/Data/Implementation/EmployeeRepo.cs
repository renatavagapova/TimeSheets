﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;
using Microsoft.EntityFrameworkCore;
using TimeSheets.Data.Ef;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly TimesheetDbContext _context;

        public EmployeeRepo(TimesheetDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> GetItem(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task Add(Employee item)
        {
            await _context.Employees.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee item)
        {
            _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Employee employee = await _context.Employees.SingleOrDefaultAsync(x => x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
