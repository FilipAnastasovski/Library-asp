using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface ILoanRepository
    {
        List<Loan> ListAll();
        Loan GetItemDetails(int id);
        void CreateNew(Loan loan);
        void UpdateExisting(Loan loan);
        void DeleteExisting(Loan loan);
    }
}
