﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IUserRepository
    {
        List<User> ListAll();
        User GetItemDetails(int id);
        void CreateNew(User user);
        void UpdateExisting(User user);
        void DeleteExisting(User user);
    }
}
