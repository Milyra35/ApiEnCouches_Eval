using ApiEnCouches.Service.DataTransferObject;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEnCouches.Service.Service
{
    public class AuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _config;

        public AuthService(UserManager<IdentityUser> userManager, TokenService tokenService, IConfiguration config)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _config = config;
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            var user = new IdentityUser { UserName = dto.Name, Email = dto.Email };
            return await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, dto.Password))
                return null;

            return _tokenService.GenerateToken((DataAccess.Entity.ApplicationUser)user);
        }
    }
}
