using Library.Models;
using Library.ViewModels;
using System.Collections.Generic;

namespace Library.Services
{
    public interface IUserService
    {
        List<User> ListAll();
        User GetUserById(int id);
        void Create(User user);
        void UpdateExisting(User user);
        void DeleteExisting(User user);
        User ChangeToModel(UserViewModel model);
        User FindUser(User user);
        User FindUserByEmail(string email);
        bool CheckIfSomeoneIsLogged();
        User FindLoggedUser();
    }
}
