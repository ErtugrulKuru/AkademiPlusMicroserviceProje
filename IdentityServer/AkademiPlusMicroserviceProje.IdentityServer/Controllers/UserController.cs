using System.Linq;
using System.Threading.Tasks;
using AkademiPlusMicroserviceProje.IdentityServer.Dtos;
using AkademiPlusMicroserviceProje.IdentityServer.Models;
using AkademiPlusMicroserviceProje.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using static IdentityServer4.IdentityServerConstants;

namespace AkademiPlusMicroserviceProje.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var user = new ApplicationUser()
            {
                UserName = signUpDto.Username,
                Email = signUpDto.Email,
                City = signUpDto.City,
                Country = signUpDto.Country,
            };
            var result=await _userManager.CreateAsync(user,signUpDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x=>x.Description).ToList(),400));
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userClaimID = User.Claims.FirstOrDefault(x =>x.Type==JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaimID.Value);
            return Ok(new {Id=user.Id,username=user.UserName,email=user.Email,city=user.City,country=user.Country});
        }
    }
}
