using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectX.Models;

namespace ProjectX.Services
{
    public interface IBookRepository
    {
        Book Add(Book book);
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Delete(Book book);
        void Update(Book book);
    }
}
