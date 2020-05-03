using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || 
                _context.Seller.Any() || 
                _context.SalesRecord.Any())
            {
                return;
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "TI");

            Seller s1 = new Seller(1, "Ricardo", "rkdtondello@gmail.com", 1000.00, new DateTime(1990, 05, 29), d1);

            SalesRecord sr1 = new SalesRecord(1, new DateTime(2020, 1, 1), 11000.00, Models.Enums.SaleStatus.Billed, s1);


            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(sr1);
            _context.SaveChanges();

        }
    }
}
