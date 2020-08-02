using GagiStoreSystem.Data;
using GagiStoreSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Helpers
{
    public static class Seed
    {
        public static async Task InvokeAsync(ApplicationDbContext context)
        {
            if(!(await context.Users.AnyAsync()) && !(await context.Claims.AnyAsync()) && !(await context.UserClaims.AnyAsync()))
            {
                Claims claims = new Claims
                {
                    Name = "Admin",
                    Type = "role",
                    Id = Convert.ToInt32(GagiStoreSystem.Enums.Claims.Admin)
                };

                User user1 = new User
                {
                    Name = "Orxan",
                    Surname = "Baxishli",
                    Photo = "orxan.jpg",
                    Username = "orxan.baxisli"
                };

                User user2 = new User
                {
                    Name = "Tərlan",
                    Surname = "Usubov",
                    Username = "tarlan.usubov",
                    Photo = "tarlan.usubov"
                };

                var salt =  Encoding.UTF8.GetBytes("buparolmexfisaxlamaqucunsaltdur");
                var user1PasswordHash = PasswordHasher.Hash("Orxan123321@@", salt);
                user1.PasswordHash = user1PasswordHash;
                user1.Salt = "buparolmexfisaxlamaqucunsaltdur";

                var user2Salt = PasswordHasher.MakeSalt();
                var user2PasswordHash = PasswordHasher.Hash("Terlan123321@@", salt);
                user2.PasswordHash = user2PasswordHash;
                user2.Salt = "buparolmexfisaxlamaqucunsaltdur";

                await context.Claims.AddAsync(claims);
                await context.SaveChangesAsync();

                await context.Users.AddAsync(user1);
                await context.Users.AddAsync(user2);
                await context.SaveChangesAsync();

                UserClaims userClaim1 = new UserClaims
                {
                    UserId = user1.Id,
                    ClaimsId = claims.Id
                };

                UserClaims userClaim2 = new UserClaims
                {
                    UserId = user2.Id,
                    ClaimsId = claims.Id
                };

                await context.UserClaims.AddAsync(userClaim1);
                await context.UserClaims.AddAsync(userClaim2);
                await context.SaveChangesAsync();
            }
        }
    }
}
