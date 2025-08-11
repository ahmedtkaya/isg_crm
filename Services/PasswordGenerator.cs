using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace isg_crm.Services
{
    public static class PasswordGenerator
    {
        public static string GeneratePassword(int length = 12)
        {
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+";
            var bytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validCharacters[bytes[i] % validCharacters.Length];
            }
            return new string(chars);
        }
    }
}