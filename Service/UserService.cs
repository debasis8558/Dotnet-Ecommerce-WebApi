using AutoMapper;
using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Repository;
using Ecommerce_Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce_Backend.Service
{
    public class UserService(IUserRepository _repo, ITokenService tokenService, IMapper mapper) : IUserService
    {
        private readonly PasswordHasher<User> _hash = new();
        public async Task Signup(SignUpDto dt)
        {
            var isExist = await _repo.GetUserByEmail(dt.Email!);
            if (isExist != null)
            {
                throw new ConflictException("Email already exist");
            }
            var user = mapper.Map<User>(dt);
            string hashedPassword = _hash.HashPassword(user, dt.Password!);
            user.Password = hashedPassword;
            await _repo.Add(user);
            await _repo.SaveChange();
        }
        public async Task<string> Login(LoginDto dt)
        {
            var user = await _repo.GetUserByEmail(dt.Email!) ?? throw new NotFoundException("user doesnot exist");

            Console.WriteLine($"User Email = {user.Email}");
            Console.WriteLine($"User Role = {user.Role}");

            var res = _hash.VerifyHashedPassword(user, user.Password!, dt.Password!);
            if (res == PasswordVerificationResult.Failed)
            {
                throw new UnauthorizedException("invalid password");
            }
            var token = tokenService.GenerateJwtToken(user.Id!,user.Email!, user.Role!);
            Console.WriteLine($"Generated token = {token}");
            return token;

        }
    }
}
