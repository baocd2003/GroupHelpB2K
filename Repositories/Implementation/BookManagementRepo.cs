using BusinessObjects;
using DataAccessObjects;
using Repositories.Interface;

namespace Repositories.Implementation
{
    public class BookManagementRepo : IBookManagementRepo
    {
        private readonly IGenericDAO<Book> _dao;
        public BookManagementRepo(IGenericDAO<Book> dao)
        {
            _dao = dao;
        }

        public void AddBook(Book book)
            => _dao.Add(book);

        public void DeleteBook(Book book)
            => _dao.Delete(book);

        public (List<Book> bookList, int pageCount) GetAvailableBooks(int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Book> books = _dao
                .Query()
                .Where(x => x.IsAvailable == true && x.Quantity !=0)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.IsAvailable == true && x.Quantity != 0)
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (books, pageCount);
        }

        public (List<Book> bookList, int pageCount) GetBookByCategory(int cateId, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Book> books = _dao
                .Query()
                .Where(x => x.IsAvailable == true && x.CategoryId.Equals(cateId))
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.IsAvailable == true && x.CategoryId.Equals(cateId))
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (books, pageCount);
        }

        public Book? GetBookById(int id)
            => _dao
                .Query()
                .Where(x => x.BookId.Equals(id))
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .SingleOrDefault();

        public (List<Book> bookList, int pageCount) GetBookNotAvailable(int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Book> books = _dao
                .Query()
                .Where(x => x.IsAvailable == false)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.IsAvailable == false)
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (books, pageCount);
        }

        public (List<Book> bookList, int pageCount) GetBookOutOfQuantity(int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Book> books = _dao
                .Query()
                .Where(x => x.Quantity.Equals(0) && x.IsAvailable == true)
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.Quantity.Equals(0) && x.IsAvailable == true)
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (books, pageCount);
        }

        public (List<Book> bookList, int pageCount) GetBooksByPublisher(int publiserId, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Book> books = _dao
                .Query()
                .Where(x => x.IsAvailable == true && x.PublisherId.Equals(publiserId))
                .Include(x => x.Publisher)
                .Include(x => x.Category)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
            int count = _dao
                .Query()
                .Where(x => x.IsAvailable == true && x.PublisherId.Equals(publiserId))
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (books, pageCount);
        }

        public void UpdateBook(Book book)
            => _dao.Update(book);
    }
}
