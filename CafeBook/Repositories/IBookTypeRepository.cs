using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CafeBook.Models;

namespace CafeBook.Repositories
{
    public interface IBookTypeRepository
    {
        void Add(BookType bookType);
        void Update(BookType bookType);
        void Delete(BookType bookType);
        Task Save();
        Task<List<BookType>> GetAll();
        Task<BookType> GetDetail(int? id);
        bool BookTypeExist(int id);
    }
}
