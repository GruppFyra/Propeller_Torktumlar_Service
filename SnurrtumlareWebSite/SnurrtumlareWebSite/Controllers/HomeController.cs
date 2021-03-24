﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SnurrtumlareWebSite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SnurrtumlareWebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Career()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            return View();
        }

        public IActionResult CustomerService()
        {
            return View();
        }

        public IActionResult DeliveryTerms()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult SocialMedia()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
