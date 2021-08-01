using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gym_back.Services.Interfaces
{
    public interface ILoginService
    {
        public string LoginUser(string userId, string password);
    }
}
