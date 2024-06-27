using BusinessObjects;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;
        public CommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public void Add(Comment comment)
            =>_commentRepo.Add(comment);

        public (List<Comment> commentList, int pageCount) GetBookComments(int bookId, int page, int pageSize)
            => _commentRepo.GetBookComments(bookId, page, pageSize);

        public Comment? GetUserCommentOnBook(int userId, int bookId)
            => _commentRepo.GetUserCommentOnBook(userId, bookId);

        public void Update(Comment comment)
            => _commentRepo.Update(comment);
    }
}
