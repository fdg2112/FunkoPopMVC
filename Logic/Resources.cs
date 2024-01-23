using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Logic
{
    public class Resources
    {
        //Encriptacion de texto en SHA256
        public static string ConvertSha256(string txt)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (SHA256 sha256 = SHA256Managed.Create()) {
                Encoding encoding = Encoding.UTF8;
                byte[] result = sha256.ComputeHash(encoding.GetBytes(txt));
                foreach (byte b in result)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
