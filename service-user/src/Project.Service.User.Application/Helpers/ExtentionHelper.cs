using Microsoft.Extensions.Configuration;
using Project.Service.User.Application.Options;
using System.Security.Cryptography;
using System.Text;

namespace Project.Service.User.Application.Helpers
{
    public static class ExtentionHelper
    {
        private static IConfiguration _configuration;

        public static void Initialize(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static bool HasProperty(this object objectToCheck, string propertyName, out object value)
        {
            var type = objectToCheck.GetType();
            var property = type.GetProperty(propertyName);
            value = property?.GetValue(objectToCheck);
            return property != null;
        }

        public static string HashPassword(string password)
        {
            if (_configuration == null)
            {
                throw new InvalidOperationException("Configuration has not been initialized.");
            }

            string secretKey = _configuration["AppSettings:SecretKey"];

            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = hmac.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
