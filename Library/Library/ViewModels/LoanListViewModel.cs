using Library.Data;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    public class LoanListViewModel
    {
        public List<Loan> AllLoans { get; set; }

        public LoanListViewModel()
        {
            AllLoans = new List<Loan>();
            foreach (var loan in Storage.Loans)
            {
                AllLoans.Add(loan);
            }
        }
    }
}
