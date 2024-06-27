using BusinessObjects;
using DataAccessObjects;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class CommentRepo : ICommentRepo
    {
        private readonly IGenericDAO<Comment> _dao;
        public CommentRepo(IGenericDAO<Comment> dao)
        {
            _dao = dao;
        }

        public void Add(Comment comment)
            => _dao.Add(comment);

        public (List<Comment> commentList, int pageCount) GetBookComments(int bookId, int page, int pageSize)
        {
            int currentPage = page < 1 ? 1 : page;
            int currentPageSize = pageSize < 1 ? 1 : pageSize;
            List<Comment> comments = _dao
            .Query()
            .Where(x => x.BookId.Equals(bookId))
            .Include(x=>x.User)
            .OrderByDescending(x => x.Timestamp)
            .Skip((currentPage - 1) * currentPageSize)
            .Take(currentPageSize)
            .ToList();
            int count = _dao
                .Query()
                .Where(x => x.BookId.Equals(bookId))
                .Count();
            int pageCount = (int)Math.Ceiling((double)count / currentPageSize);
            return (comments,pageCount);
        }
        public Comment? GetUserCommentOnBook(int userId, int bookId)
        {
            return _dao
                .Query()
                .Where(x => x.UserId.Equals(userId) && x.BookId.Equals(bookId))
                .SingleOrDefault();
        }
        public void Update(Comment comment)
            => _dao.Update(comment);
    }
}
