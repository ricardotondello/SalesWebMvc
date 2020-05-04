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
        public void Insert(Seller obj)
        {
            obj.Departament = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
