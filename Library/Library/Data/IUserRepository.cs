using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
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
