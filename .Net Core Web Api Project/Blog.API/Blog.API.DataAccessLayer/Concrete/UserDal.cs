using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Blog.API.Entity.Context;
using Blog.API.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.API.DataAccessLayer.Concrete
{
    public class UserDal : IUserDal
    {
        private readonly BlogContext _context;
        public UserDal(BlogContext context)
        {
            _context = context;
        }

        public bool Login(UserDTO user)
        {
            return (from u in _context.User
                    where u.Email.Equals(user.Email)
                    && u.Password.Equals(user.Password)
                    select u).Any();


        }

        public async Task<bool> Register(UserDTO user)
        {
            try
            {
                var result = (from u in _context.User
                              where u.Email.Equals(user.Email)
                              || u.Username.Equals(user.Username)
                              select u).Any();

                if (result)
                {
                    return false;
                }

                _context.User.Add(new User
                {
                    Email = user.Email,
                    Password = user.Password,
                    Username = user.Username
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw; // should write log...
            }
        }

        public async Task<int> GetUserId(string userMail)
        {
            return _context.User.FirstOrDefault(x => x.Email.Equals(userMail)).Id;
        }

        public async Task<bool> AddAdminAbout(AboutDTO about)
        {
            try
            {
                var userId = await GetUserId(about.UserMail);
                _context.AdminUserAbout.Add(new AdminUserAbout
                {
                    AboutText = about.AboutText,
                    CreatedBy = userId,
                    IsActive = true,
                    UserId = userId
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> UpdateAdminUserAbout(AboutDTO about)
        {
            try
            {
                var admin = _context.AdminUserAbout.Where(x => x.User.Email.Equals(about.UserMail)).FirstOrDefault();
                admin.AboutText = about.AboutText;
                admin.ModifiedBy = admin.UserId;
                admin.ModifiedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<AboutDTO> GetAbout(string adminMail)
        {
            return await (from admin in _context.AdminUserAbout
                    where admin.User.Email.Equals(adminMail) 
                    || admin.User.Username.Equals(adminMail)
                    select new AboutDTO
                    {
                        AboutText = admin.AboutText
                    }).FirstOrDefaultAsync();
        }
    }
}
