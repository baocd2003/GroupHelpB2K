using BusinessObjects;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class BookManagementService : IBookManagementService
    {
        private readonly IBookManagementRepo _bookRepo;
        public BookManagementService(IBookManagementRepo bookManagementRepo)
        {
            _bookRepo = bookManagementRepo;
        }

        public void AddBook(Book book)
        => _bookRepo.AddBook(book);

        public void DeleteBook(Book book)
        => _bookRepo.DeleteBook(book);

        public (List<Book> bookList, int pageCount) GetAvailableBooks(int page, int pageSize)
        => _bookRepo.GetAvailableBooks(page, pageSize);

        public (List<Book> bookList, int pageCount) GetBookByCategory(int cateId, int page, int pageSize)
        => _bookRepo.GetBookByCategory(cateId, page, pageSize);

        public Book? GetBookById(int id)
        => _bookRepo.GetBookById(id);

        public (List<Book> bookList, int pageCount) GetBookNotAvailable(int page, int pageSize)
        => _bookRepo.GetBookNotAvailable(page, pageSize);

        public (List<Book> bookList, int pageCount) GetBookOutOfQuantity(int page, int pageSize)
        => _bookRepo.GetBookOutOfQuantity(page, pageSize);

        public (List<Book> bookList, int pageCount) GetBooksByPublisher(int publiserId, int page, int pageSize)
        => _bookRepo.GetBooksByPublisher(publiserId, page, pageSize);

        public void UpdateBook(Book book)
        => _bookRepo.UpdateBook(book);
    }
}
