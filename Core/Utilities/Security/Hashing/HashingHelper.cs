using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var Hmac = new HMACSHA512())
            {
                passwordSalt = Hmac.Key;
                passwordHash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var Hmac = new HMACSHA512(passwordSalt))
            {
                var computeHash = Hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i <computeHash.Length;  i++)
                {
                    if (computeHash[i] == passwordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}