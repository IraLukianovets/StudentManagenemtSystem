using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace StudentSystem.API.AppSettings
{
    public class AuthOptions
    {
        public const string Issuer = "StudentSystem";

        public const string Audience = "http://localhost:51884/";

        const string Key = "2c2c4c65-a130-43ac-9cfd-694e297bb763";

        public const int Lifetime = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}