using System.Security.Claims;
using System.Text;
using Ecommerce_Backend.Dto;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce_Backend.Service
{
    public class TokenService(IConfiguration configuration) : ITokenService
    {
        public string GenerateJwtToken(int Id,string Email,string Role)
        {
            var secretKey=configuration["jwt:Secret"]!;
            var securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials=new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var tokenDescriptor= new SecurityTokenDescriptor
            {
                Subject=new System.Security.Claims.ClaimsIdentity([
                    new Claim(ClaimTypes.NameIdentifier,Id.ToString()),
                    new Claim(ClaimTypes.Email,Email),
                    new Claim(ClaimTypes.Role,Role)
                ]),
                Expires=DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["jwt:TokenExpairyInMintues"])),
                SigningCredentials=credentials,
                Issuer=configuration["jwt:Issuer"],
                Audience=configuration["jwt:Audience"]
            };
            var tokenHandler=new JsonWebTokenHandler();
            var token=tokenHandler.CreateToken(tokenDescriptor);//gives the jwt token
            return token;

        }
    }
}