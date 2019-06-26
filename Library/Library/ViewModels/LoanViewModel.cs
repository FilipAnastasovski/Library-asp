using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Library.ViewModels
{
    public class LoanViewModel
    {
        public List<SelectListItem> Books { get; set; }
        public string SelectedBook { get; set; }

        public LoanViewModel()
        {
            Books = new List<SelectListItem>();

            foreach (var book in Storage.Books)
            {
                Books.Add(new SelectListItem
                {
                    Text = book.Name,
                    Value = book.Id.ToString()
                });
            }
        }
    }
}
