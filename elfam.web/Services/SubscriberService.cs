using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using elfam.web.Models;

namespace elfam.web.Services
{
    public class SubscriberService
    {
        
        /// <returns>Base64 token</returns>
        public static string CalculateToken(string email)
        {
            var token_email = string.Format("{0} {1}", Subscriber.UnsubscribeKey, email);
            var token_email_bytes = Encoding.UTF8.GetBytes(token_email);
            var hash = new SHA256Managed().ComputeHash(token_email_bytes);
            var hash_base64 = Convert.ToBase64String(hash);
            return hash_base64;
        }

        public static bool VerifyToken(string email, string base64token)
        {
            var inputBytes = Encoding.UTF8.GetBytes(string.Format("{0} {1}", Subscriber.UnsubscribeKey, email));
            var inputHash = new SHA256Managed().ComputeHash(inputBytes);
            var inputBase64 = Convert.ToBase64String(inputHash);
            return inputBase64.Equals(base64token);
        }
    }
}
