namespace QBOID;
using System.Security.Cryptography;
using System.Text;

public class Sha512
{
        public static StringBuilder Sha512AuthHash(string requestKey,string apiKey = "MDUzMTkxN2ItMjliOS00MmVmLWI5MDEtNGQ5YTliNDZiMzIy\r\n",
         string apiSecret = "YTBjYmE1ZGYtNjQ1ZC00YzU1LWI2NmEtYzYzYjRjZTdjMTUy")
        {
            StringBuilder ToHash = new StringBuilder();
            ToHash.Append(apiKey);
            ToHash.Append(requestKey);
            ToHash.Append(apiSecret);
            var message = Encoding.UTF8.GetBytes(ToHash.ToString());
            var hex = new StringBuilder();
            using (var sha512 = SHA512.Create())
            {
                var hashValue = sha512.ComputeHash(message);

                foreach (byte x in hashValue)
                {
                    hex.Append(string.Format("{0:x2}", x));
                }
                return hex;
            }
        }

}
