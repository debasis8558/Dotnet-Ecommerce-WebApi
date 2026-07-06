using Ecommerce_Backend.Dto;

namespace Ecommerce_Backend.Service
{
    public interface ITokenService
    {
        string GenerateJwtToken(int Id,string Email,string Role);
    }
}