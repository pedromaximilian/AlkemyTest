using AlkemyTest.Data.CustomResponse;
using AlkemyTest.Data.Services;
using AlkemyTest.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private UserService _userService;
        private MailService _mailService;

        public AuthController(UserService userService, MailService mailService)
        {
            _userService = userService;
            _mailService = mailService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterVM userRegisterVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _userService.Register(userRegisterVM);

                    if (response.IsSuccess)
                    {
                        //await _mailService.SendMail(userRegisterVM.Email, "New Register", "<h1>Congrats! You are now registered</h1>");
                        return Ok(response);
                    }
                    return BadRequest(response);
                }
                else
                {
                    return BadRequest("Invalid Model");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.Login(loginVM);

                if (result.IsSuccess)
                {
                    await _mailService.SendMail(loginVM.Email, "New Register", "<h1>Congrats! You are now registered</h1>");
                    return Ok(result);
                }
                else
                {

                    return BadRequest(result);
                }
            }
            return BadRequest("Invalid properties");
        }
    }
}
