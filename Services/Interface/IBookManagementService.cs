using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IBookManagementService
    {
        public void AddBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(Book book);
        public Book? GetBookById(int id);
        public (List<Book> bookList, int pageCount) GetAvailableBooks(int page, int pageSize);
        public (List<Book> bookList, int pageCount) GetBooksByPublisher(int publiserId, int page, int pageSize);
        public (List<Book> bookList, int pageCount) GetBookByCategory(int cateId, int page, int pageSize);
        public (List<Book> bookList, int pageCount) GetBookOutOfQuantity(int page, int pageSize);
        public (List<Book> bookList, int pageCount) GetBookNotAvailable(int page, int pageSize);
    }
}
