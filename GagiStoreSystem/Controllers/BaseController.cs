using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GagiStoreSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GagiStoreSystem.Controllers
{
    public class BaseController : Controller
    {
        private ApplicationDbContext _context;
        public ApplicationDbContext Context => _context ??= HttpContext.RequestServices.GetService<ApplicationDbContext>();
    }
}
