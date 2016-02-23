namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface ICommentsService
    {
        Comment AddNew(Comment toAdd);

        IQueryable<Comment> AllByEntity(int id);

        void DeleteCommentById(int id);
    }
}
