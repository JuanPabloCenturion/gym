using gym_back.Model;
using System.Threading.Tasks;

namespace gym_back.Services.Interfaces
{
    public interface ILoginService
    {
        public Task<Account> LoginUserAsync(string userId, string password);
    }
}
