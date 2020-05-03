﻿using System.Collections.Generic;
using System.Linq;
using SalesWebMvc.Models;
using SalesWebMvc.Data;

namespace SalesWebMvc.Services
{
    public class SellersService 
    {
        private readonly SalesWebMvcContext _context;

        public SellersService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
