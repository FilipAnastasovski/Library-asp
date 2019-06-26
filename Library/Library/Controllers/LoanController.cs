using Library.Models;
using Library.Services;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Library.Controllers
{
    public class LoanController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly ILoanService _loanService;
        public LoanController(IUserService userService,IBookService bookService, ILoanService loanService)
        {
            _userService = userService;
            _bookService = bookService;
            _loanService = loanService;
        }

        public IActionResult Index()
        {
            var loans = new LoanListViewModel();
            return View(loans);
        }

        [HttpGet]
        public IActionResult LoanBooks()
        {
            var loan = new LoanViewModel();
            return View(loan);
        }

        [HttpPost]
        public IActionResult LoanBooks(LoanViewModel model)
        {
            var bookIsAvailable = _loanService.CheckIfBookIsAvailable(model.SelectedBook);
            var userHasTheBook = _loanService.CheckIfUserHasTheBook(model.SelectedBook);
            var moreThan3 = _loanService.LoanedMoreThan3();
            if (!bookIsAvailable)
            {
                ModelState.AddModelError("CustomError", "The book isn't available.");
                return View(model);

            }else if (userHasTheBook)
            {
                ModelState.AddModelError("CustomError", "You have already loaned the book .");
                return View(model);
            }else if (moreThan3)
            {
                ModelState.AddModelError("CustomError", "You have already loaned 3 books, can't have more ");
                return View(model);
            }
            _loanService.CreateLoan(model);
            return RedirectToAction("LogIn", "User");
        }

        [HttpGet]
        public IActionResult ReturnBook(int id)
        {
            _loanService.ReturnBook(id);
            return RedirectToAction("LogIn", "User");
        }

    }
}