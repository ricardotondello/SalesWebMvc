﻿using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SalesRecordsService
    {
        private readonly SalesWebMvcContext _context;

        public SalesRecordsService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? dtMin, DateTime? dtMax)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (dtMin.HasValue)
            {
                result = result.Where(x => x.Date >= dtMin.Value);
            }
            if (dtMax.HasValue)
            {
                result = result.Where(x => x.Date <= dtMax.Value);
            }

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Departament)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }
    }
}
