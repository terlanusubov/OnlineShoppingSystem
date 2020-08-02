using GagiStoreSystem.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Helpers
{
    public static class Identity
    {
        public static async Task SignInAsync(User user,HttpContext context)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("name",user.Name),
                new Claim("surname",user.Surname),
                new Claim("role",user.Claims.Where(c=>c.Claims.Type == "role").Select(c=>c.Claims.Id).FirstOrDefault().ToString())
            };


            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
        }
    }
}
