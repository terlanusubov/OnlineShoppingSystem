using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GagiStoreSystem.Data;
using GagiStoreSystem.Infrastructure.Helpers;
using GagiStoreSystem.Infrastructure.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GagiStoreSystem.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Login()
        {
            return View(new LoginM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            //istifadecini tap
            var user = await Context.Users.Where(c => c.Username == model.Username).FirstOrDefaultAsync();
            if (user == null)
            {
                ModelState.AddModelError("", "Belə bir istifadəçi yoxdur.");
                return View(model);
            }

            //parolu yoxla
            byte[] salt = Encoding.UTF8.GetBytes(user.Salt);
            bool result =  PasswordHasher.Check(model.Password, salt, user.PasswordHash);
            if (result)
            {
                await Identity.SignInAsync(user,HttpContext);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Istifadəçi adı və ya şifrə yanlışdır.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
