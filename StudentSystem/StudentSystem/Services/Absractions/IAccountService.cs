using System.Threading.Tasks;
using StudentSystem.API.Models;

namespace StudentSystem.API.Services.Absractions
{
    public interface IAccountService : IBaseService
    {
        /// <summary>
        /// Authorizates user in system
        /// </summary>
        /// <param name="account">Instance of <see cref="AuthRequestApiModel"/> class</param>
        /// <returns>Returns instance of <see cref="AuthResponseApiModel"/> class or null</returns>
        Task<AuthResponseApiModel> Auth(AuthRequestApiModel account);

        /// <summary>
        /// Registers user in system
        /// </summary>
        /// <param name="newuser">Instance of <see cref="RegisterRequestApiModel"/> class</param>
        /// <returns>Returns instance of <see cref="RegisterResponseApiModel"/> class or null</returns>
        Task<bool> Register(RegisterRequestApiModel newuser);
    }
}
