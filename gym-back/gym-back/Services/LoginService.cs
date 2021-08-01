using gym_back.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Services
{
    public class LoginService : ILoginService
    {
        public string LoginUser(string userId, string password)
        {
            return "Hola";
        }
    }
}
