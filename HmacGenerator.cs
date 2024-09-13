using System.Security.Cryptography;
using System.Text;
namespace Task_3
{


    public class HmacGenerator
    {
        private readonly byte[] _key;

        public HmacGenerator()
        {
            _key = GenerateRandomKey();
        }

        private byte[] GenerateRandomKey()
        {
            using var rng = new RNGCryptoServiceProvider();
            var key = new byte[32];
            rng.GetBytes(key);
            return key;
        }

        public (string Hmac, string Key) GenerateHmac(string move)
        {
            using var hmac = new HMACSHA256(_key);
            var moveBytes = Encoding.UTF8.GetBytes(move);
            var hashBytes = hmac.ComputeHash(moveBytes);
            var hmacString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            var keyString = BitConverter.ToString(_key).Replace("-", "").ToLower();

            return (hmacString, keyString);
        }
    }

}