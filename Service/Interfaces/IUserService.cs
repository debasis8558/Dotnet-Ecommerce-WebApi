using Ecommerce_Backend.Dto;

namespace Ecommerce_Backend.Service
{
    public interface IUserService
    {
        Task Signup(SignUpDto dt);
          Task<string> Login(LoginDto dt);
    }
}