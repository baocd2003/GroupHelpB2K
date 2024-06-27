using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICommentRepo
    {
        void Add(Comment comment);
        (List<Comment> commentList, int pageCount) GetBookComments(int bookId, int page, int pageSize);
        void Update(Comment comment);
        public Comment? GetUserCommentOnBook(int userId, int bookId);
    }
}
