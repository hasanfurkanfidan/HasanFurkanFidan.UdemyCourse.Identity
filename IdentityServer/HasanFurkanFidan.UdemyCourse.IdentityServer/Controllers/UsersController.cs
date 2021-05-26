using HasanFurkanFidan.UdemyCourse.IdentityServer.CustomFilterAttributes;
using HasanFurkanFidan.UdemyCourse.IdentityServer.Dtos;
using HasanFurkanFidan.UdemyCourse.IdentityServer.Models;
using HasanFurkanFidan.UdemyCourse.SHARED.ControllerBases;
using HasanFurkanFidan.UdemyCourse.SHARED.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HasanFurkanFidan.UdemyCourse.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : CustomBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [ValidModel]
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto model)
        {
            var user = new ApplicationUser();
            user.UserName = model.UserName;
            user.Email = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                CreateActionResultInstance(Response<NoContent>.Fail(result.Errors.Select(p=>p.Description).ToList(),404));
            }
            return NoContent();
        }
    }
}
