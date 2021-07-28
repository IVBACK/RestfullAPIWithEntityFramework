﻿using ComputerAPP.CORE.Models;
using System.Collections.Generic;

namespace ComputerAPP.SERVICE.IRepos
{
    interface IUserRepo
    {
        void SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
