using AlkemyTest.Data.CustomResponse;
using AlkemyTest.Data.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AlkemyTest.Data.Services
{
    public class UserService
    {

        public UserManager<IdentityUser> _userManager { get; set; }
        public IConfiguration _configuration { get; set; }

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }



        public async Task<GenericResponse> Register(UserRegisterVM _userRegisterVM)
        {

            if (_userRegisterVM == null)
            {
                throw new("model is null");
            }

            var User = new IdentityUser
            {
                Email = _userRegisterVM.Email,
                UserName = _userRegisterVM.Email,
            };


            if (_userRegisterVM.Password != _userRegisterVM.PasswordConfirm)
            {
                return new GenericResponse
                {
                    Message = "Password dont match password_confirm",
                    IsSuccess = false
                
                };
            }

            var result = await _userManager.CreateAsync(User, _userRegisterVM.Password);


            if (result.Succeeded)
            {
                return new GenericResponse
                {
                    IsSuccess = true,
                    Message = "Created successfully"
                };
            }
            else
            {
                return new GenericResponse
                {
                    IsSuccess = false,
                    Message = "User did not created",
                    Errors = result.Errors.Select(x => x.Description).ToList()
                };
            }

        }




        public async Task<GenericResponse> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByEmailAsync(loginVM.Email);

            if (user == null)
            {
                return new GenericResponse
                {
                    IsSuccess = false,
                    Message = "Please check user and password"
                };


            }

            var result = await _userManager.CheckPasswordAsync(user, loginVM.Password);

            if (!result)
            {
                return new GenericResponse
                {
                    IsSuccess = false,
                    Message = "Please check user and password"
                };
            }


            //TODO: check required claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, loginVM.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };



            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenAuthentication:SecretKey"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["TokenAuthentication:Issuer"],
                audience: _configuration["TokenAuthentication:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));



            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return new GenericResponse
            {
                Message = tokenString,
                IsSuccess = true,
                ExpireDate = token.ValidTo
            };
                

        }
    }
}
