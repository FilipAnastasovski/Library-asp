using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Data
{
    public interface IAuthorRepository
    {
        List<Author> ListAll();
        Author GetItemDetails(int id);
        void CreateNew(Author author);
        void UpdateExisting(Author author);
        void DeleteExisting(Author author);
    }
}
