using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.IO;
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

        public static string GeneratePassword()
        {
            string password = Guid.NewGuid().ToString("N").Substring(0,8);
            return password;
        }

        public static bool SendEmail(string email, string subject, string message) {
            bool result = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("fdg2112@gmail.com");
                mail.Subject = subject;
                mail.Body = message;
                mail.IsBodyHtml = true;

                var smtp = new SmtpClient()
                {
                    Credentials = new NetworkCredential("fdg2112@gmail.com", "pyowqbtebkzztktc"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };

                smtp.Send(mail);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
