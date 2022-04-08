using System.Security.Cryptography;
using System.Text;

namespace FindJobWebApi.Secure
{
    public static class SecurePassword
    {
        public static string getHash(this string password)
        {
            
            string salt = "fkjflefjek22";
            var hasher = MD5.Create();
            var bytes = Encoding.ASCII.GetBytes(password);
            var hash = hasher.ComputeHash(bytes);
            string result = Convert.ToHexString(hash);

            return Convert.
                ToHexString(hasher.
                            ComputeHash(Encoding.ASCII.GetBytes(result + salt)));
            
        }
    }
}
