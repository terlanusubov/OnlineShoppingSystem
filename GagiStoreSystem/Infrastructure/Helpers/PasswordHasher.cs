using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading.Tasks;

namespace GagiStoreSystem.Infrastructure.Helpers
{
    public static class PasswordHasher
    {
        public static string Hash(string password,byte[] salt)
        {
            
            

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
        public static byte[] MakeSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public static bool Check(string checkPassword,byte[] salt,string passwordHash)
        {
            var checkPasswordHash = Hash(checkPassword,salt);
            return checkPasswordHash == passwordHash;
        }


    }
}
