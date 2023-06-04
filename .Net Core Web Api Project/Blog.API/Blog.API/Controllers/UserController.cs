using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDal _userDal;
        public UserController(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [HttpPost, ActionName("AddAdminUser")]
        public async Task<bool> AddAdminUser(UserDTO userDto)
        {
            return await _userDal.Register(userDto);
        }

        [HttpGet]
        public bool Login(UserDTO userDto)
        {
            return _userDal.Login(userDto);
        }
    }
}
