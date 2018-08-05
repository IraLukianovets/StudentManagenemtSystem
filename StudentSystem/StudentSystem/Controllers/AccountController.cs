using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentSystem.API.Models;
using StudentSystem.API.Services.Absractions;

namespace StudentSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [System.Web.Http.HttpPost]
        public async Task Auth([FromHeader]string username, [FromHeader]string password)
        {
            var authResult = await accountService.Auth(new AuthRequestApiModel
            {
                Username = username,
                Password = password
            });

            if (string.IsNullOrEmpty(authResult.AccessToken))
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }

            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(authResult,
                new JsonSerializerSettings {Formatting = Formatting.Indented}));
        }

        [System.Web.Http.HttpPost]
        public async Task<IActionResult> Register(RegisterRequestApiModel registerModel)
        {
            if(ModelState.IsValid)
            {
                var registerResult = await accountService.Register(registerModel);

                if (registerResult)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }
    }
}