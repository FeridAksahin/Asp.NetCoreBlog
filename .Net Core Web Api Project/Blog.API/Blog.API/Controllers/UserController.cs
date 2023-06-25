using Blog.API.Authentication;
using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDal _userDal;
        private readonly IConfiguration _configuration;
        public UserController(IUserDal userDal, IConfiguration configuration)
        {
            _userDal = userDal;
            _configuration = configuration;
        }

        [HttpGet]
        public Token GetToken()
        {
            return TokenHandler.CreateToken(_configuration);
         
        }
      
        [HttpGet("{email}/{password}")]
        public string Login(string email, string password)
        {
            if(_userDal.Login(new UserDTO { Email = email, Password = password }))
            {
                return GetToken().AccessToken;
            }
            return null; 
        }

        [HttpPost, ActionName("AddAdminUser")]
        public async Task<StatusCodeResult> AddAdminUser(UserDTO userDto)
        {
            var isRegistered = await _userDal.Register(userDto);
            if (isRegistered)
            {
                return StatusCode(StatusCodes.Status201Created);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        } 
    }
}

