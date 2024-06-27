using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICommentService
    {
        void Add(Comment comment);
        (List<Comment> commentList, int pageCount) GetBookComments(int bookId, int page, int pageSize);
        void Update(Comment comment);
        public Comment? GetUserCommentOnBook(int userId, int bookId);
    }
}
