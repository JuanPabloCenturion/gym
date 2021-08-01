using gym_back.Services.Interfaces;
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
        public string Login(string userId, string password)
        {
            try
            {
                return this.loginService.LoginUser(userId, password);
            }
            catch
            {
                return "ok";
            }
        }
       
    }
}
