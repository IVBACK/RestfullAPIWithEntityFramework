﻿using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.IRepos;
using ComputerAPP.SERVICE.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAPP.SERVICE.SqlRepos
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly ComputerAppDBContext db_Context;

        private UserValidation userValidation = new UserValidation();

        public SqlUserRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }
        
        public bool CreateUser(User user)
        {
            if(userValidation.IsNameValid(user.Name) && userValidation.IsEmailValid(user.Mail))
            {
                db_Context.Users.Add(user);
                SaveChanges();
                return true;
            }
            return false;           
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var user = db_Context.Users.Find(id);
                db_Context.Users.Remove(user);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return db_Context.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }          
        }

        public User GetUserById(int id)
        {
            try
            {
                return db_Context.Users.FirstOrDefault(p => p.UserId == id);
            }
            catch (Exception)
            {
                return null;
                throw;
            }           
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public bool UpdateUser(User user)
        {
            try
            {
                db_Context.Entry(user).State = EntityState.Modified;
                SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}