namespace QBOID;
using System.Security.Cryptography;
using System.Text;

public class Sha512
{
        public static StringBuilder Sha512AuthHash(string requestKey,string apiKey = "OWY2NDUyZjUtYTQ4MC00NjA1LWI3NDctODRmN2QwYjFlNjli",
         string apiSecret = "MjM1MTg3OWMtOThmYS00ZDY1LTlmMzQtMzEyMTJmNWQxOGQz")
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
