using System.Text;
using System.Security.Cryptography; 

namespace Task4
{
    public static class HMACGenerator
    {
        public static string GenerateHMAC(string message, byte[] key)
        {
            using (var hmac = new HMACSHA3_256(key))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));

                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}