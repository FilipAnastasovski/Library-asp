﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class UserRepository : IUserRepository
    {
        public void CreateNew(User user)
        {
            Storage.Users.Add(user);
        }

        public void DeleteExisting(User user)
        {
            Storage.Users.Remove(user);
        }

        public User GetItemDetails(int id)
        {
            return Storage.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<User> ListAll()
        {
            return Storage.Users;
        }

        public void UpdateExisting(User user)
        {
            var foundUser = Storage.Users.FirstOrDefault(x => x.Id == user.Id);
            foundUser.Email = user.Email;
            foundUser.Password = user.Password;
            foundUser.Role = user.Role;
            foundUser.IsLogged = user.IsLogged;
        }
    }
}