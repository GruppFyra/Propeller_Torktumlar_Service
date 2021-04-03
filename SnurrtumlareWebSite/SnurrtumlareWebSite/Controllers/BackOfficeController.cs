﻿using Microsoft.AspNetCore.Mvc;
using SnurrtumlareWebSite.Services;
using SnurrtumlareWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SnurrtumlareWebSite.Controllers
{
    public class BackOfficeController : Controller
    {
        OrdersService ordersService = new OrdersService();
        ProductsService productsService = new ProductsService();
        CustomersService customersService = new CustomersService();

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewBag.Admin = 1;
            return View();
        }

        public IActionResult Products()
        {
            var listOfProducts = productsService.GetAllProducts();

            return View(listOfProducts);
        }

        public IActionResult Orders()
        {
            var listOfOrders = ordersService.Get();
            
            return View(listOfOrders);
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Customers()
        {
            var listOfCustomers = GetCustomers();
            return View(listOfCustomers);
        }
        private IEnumerable<User> GetCustomers()
        {
            return customersService.GetAllCustomers();
        }
    }
}
