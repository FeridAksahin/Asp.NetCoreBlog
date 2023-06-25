using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminFeatureController : ControllerBase
    {
        private readonly string _errorMessage = "An error occurred.";
        private readonly IUserDal _userDal;
        public AdminFeatureController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [HttpGet("{email}")]
        [AllowAnonymous]
        public async Task<AboutDTO> GetAbout(string email)
        {
            return await _userDal.GetAbout(email);
        }

        [HttpPost]
        public async Task<IActionResult> AddAboutForAdmin(AboutDTO aboutDto)
        {
            if (await _userDal.AddAdminAbout(aboutDto))
            {
                var response = new { status = "success", message = "The about text addition process has been successfully completed.", title = "Insert" };
                return Ok(response);
            }
            else
            {
                var response = new { status = "error", message = _errorMessage, title = "Insert" };
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutForAdmin(AboutDTO aboutDto)
        {
            if (await _userDal.UpdateAdminUserAbout(aboutDto))
            {
                var response = new { status = "success", message = "The about text update process has been successfully completed.", title = "Update" };
                return Ok(response);
            }
            else
            {
                var response = new { status = "error", message = _errorMessage, title = "Update" };
                return BadRequest(response);
            }
        }
    }
}
