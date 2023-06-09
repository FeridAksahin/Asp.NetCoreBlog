﻿using Blog.API.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.DataAccessLayer.Interface
{
    public interface IUserDal
    {
        public bool Login(UserDTO user);
        public Task<bool> Register(UserDTO user);
        public Task<int> GetUserId(string userMail);
        public Task<bool> UpdateAdminUserAbout(AboutDTO about);
        public Task<bool> AddAdminAbout(AboutDTO about);
        public Task<AboutDTO> GetAbout(string adminMail);
    }
}
