using Blog.API.DataAccessLayer.Interface;
using Blog.API.DataTransferObject;
using Blog.API.Entity.Context;
using Blog.API.Entity.Entity;

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
            var result = from u in _context.User
                         where u.Email.Equals(user.Email)
                         && u.Password.Equals(user.Password)
                         select u;

            return result != null;
        }

        public async Task<bool> Register(UserDTO user)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.User.Add(new User
                    {
                        Email = user.Email,
                        Password = user.Password,
                        Username = user.Username
                    });
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                    throw; // should write log...
                }
            }
        }
    }
}
