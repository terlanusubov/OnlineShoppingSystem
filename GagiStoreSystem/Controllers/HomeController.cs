using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GagiStoreSystem.Attributes;
using GagiStoreSystem.Data;
using GagiStoreSystem.Enums;
using GagiStoreSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GagiStoreSystem.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            HomeM model = new HomeM
            {
                TotalPostedProducts = await _context.Products.CountAsync()
            };
            return View(model);
        }
    }
}
