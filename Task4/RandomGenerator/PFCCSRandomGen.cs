using System.Security.Cryptography;

using Task4;
using Task4.UserInteractions;
namespace Task4.RandomGenerator
{
    public class PFCCSRandomGen : IRandomNumberService
    {
        private IUserInterface _ui;

        public PFCCSRandomGen()
        {
            _ui = new ConsoleUI();
        }

        public (int, string, byte[]) GetMortyNum(int n)
        {
            int mortyKey = RandomNumberGenerator.GetInt32(n);
            byte[] secretKey = this.GenerateSecretKey();
            string hmac = HMACGenerator.GenerateHMAC(mortyKey.ToString(), secretKey);

            return (mortyKey, hmac, secretKey);
        }

        public int GetResultNumber(int mortyKey, int rickKey, int n)
        {
            return (mortyKey + rickKey) % n;
        }

        public byte[] GenerateSecretKey()
        {
            byte[] key = RandomNumberGenerator.GetBytes(32);
            return key;
        }
    }
}