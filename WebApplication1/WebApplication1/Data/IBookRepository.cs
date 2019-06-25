using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public interface IBookRepository
    {
        List<Book> ListAll();
        Book GetItemDetails(int id);
        void CreateNew(Book book);
        void UpdateExisting(Book book);
        void DeleteExisting(Book book);
    }
}
