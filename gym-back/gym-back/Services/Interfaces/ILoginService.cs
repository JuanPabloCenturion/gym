using gym_back.Model;

namespace gym_back.Services.Interfaces
{
    public interface ILoginService
    {
        public Account LoginUser(string userId, string password);
    }
}
