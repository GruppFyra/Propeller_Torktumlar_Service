﻿using Microsoft.EntityFrameworkCore;
using SnurrtumlareWebSite.Data;
using SnurrtumlareWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnurrtumlareWebSite.Services
{
    public class OrdersService
    {
        private readonly SnurrtumlareDbContext _context;

        public OrdersService(SnurrtumlareDbContext context)
        {
            _context = context;
        }


        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.Include(o => o.User).ToListAsync();
        }

        public async Task<Order> GetOrderDetailsById(int? id)
        {
            return await _context.Orders
                            .Include(o => o.User)
                            .FirstOrDefaultAsync(m => m.OrderId == id);
        }

        public async Task UpdateOrderDetails(Order order)
        {
            _context.Update(order);
            await _context.SaveChangesAsync();
        }

        public bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

    }
}