﻿using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoanService _loanService;
        public UserController(IUserService userService, ILoanService loanService)
        {
            _userService = userService;
            _loanService = loanService;
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            if (_userService.CheckIfSomeoneIsLogged())
            {
                var foundUser = _userService.FindLoggedUser();
                ViewBag.ActiveLoans = _loanService.ListAllLoans().Where(x => x.User == foundUser && x.Status == LoanStatusEnum.Active);
                ViewBag.PastLoans = _loanService.ListAllLoans().Where(x => x.User == foundUser && x.Status == LoanStatusEnum.Finished);
                return View("ShowUser", foundUser);
            }
            UserViewModel user = new UserViewModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult ShowUser(UserViewModel model)
        {
            User user = _userService.ChangeToModel(model);
            var foundUser = _userService.FindUser(user);
            if(foundUser == null)
            {
                ModelState.AddModelError("CustomError", "The user name or password is incorrect");
                return View("LogIn", model);
            }
            foundUser.IsLogged = true;
            ViewBag.ActiveLoans = _loanService.ListAllLoans().Where(x => x.User == foundUser && x.Status == LoanStatusEnum.Active);
            ViewBag.PastLoans = _loanService.ListAllLoans().Where(x => x.User == foundUser && x.Status == LoanStatusEnum.Finished);
            return View(foundUser);
        }

        [HttpGet]
        public IActionResult LogOut(int id)
        {
            User user = _userService.GetUserById(id);
            user.IsLogged = false;
            return RedirectToAction("LogIn", "User");
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            var newUser = new User();
            return View(newUser);
        }

        [HttpPost]
        public IActionResult ChangePassword(User user)
        {
            var loggedUser = _userService.FindLoggedUser();
            user.Id = loggedUser.Id;
            user.Email = loggedUser.Email;
            user.IsLogged = loggedUser.IsLogged;
            user.Role = loggedUser.Role;
            _userService.UpdateExisting(user);
            return View("ShowUser",user);
        }
    }
}