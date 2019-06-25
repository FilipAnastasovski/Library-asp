﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
   
        public class AuthorController : Controller
        {
            private readonly IAuthorService _authorService;
            private readonly IBookService _bookService;
            public AuthorController(IAuthorService authorService, IBookService bookService)
            {
                _authorService = authorService;
                _bookService = bookService;
            }
            public IActionResult Index()
            {
                var allAuthors = new AuthorViewModel();
                return View(allAuthors);
            }

            [HttpGet]
            public IActionResult Details(int id)
            {
                var author = _authorService.GetAuthorById(id);
                ViewBag.AuthorBooks = _bookService.ListAllBooks().Where(x => x.Author == author);
                return View(author);
            }

            [HttpGet]
            public IActionResult Create()
            {
                var author = new Author();
                return View(author);
            }

            [HttpPost]
            public IActionResult Create(Author author)
            {
                if (!ModelState.IsValid)
                {
                    return View(author);
                }
                _authorService.CreateAuthor(author);
                return RedirectToAction("Index", "Author");
            }

            [HttpGet]
            public IActionResult Edit(int id)
            {
                var author = _authorService.GetAuthorById(id);
                return View(author);
            }

            [HttpPost]
            public IActionResult Edit(Author author)
            {
                if (!ModelState.IsValid)
                {
                    return View(author);
                }
                _authorService.UpdateExistingAuthor(author);
                return RedirectToAction("Index", "Author");
            }

            [HttpGet]
            public IActionResult Delete(int id)
            {
                var author = _authorService.GetAuthorById(id);
                _authorService.DeleteExisting(author);
                return RedirectToAction("Index");
            }
        }
    }