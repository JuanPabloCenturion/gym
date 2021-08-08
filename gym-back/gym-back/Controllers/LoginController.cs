using gym_back.Model;
using gym_back.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<Account> LoginAsync(string userId, string password)
        {
            return await this.loginService.LoginUserAsync(userId, password);
        }

        [HttpGet]
        [Authorize]
        public string Saludo()
        {
            return "Hola";
        }
       
    }
}
