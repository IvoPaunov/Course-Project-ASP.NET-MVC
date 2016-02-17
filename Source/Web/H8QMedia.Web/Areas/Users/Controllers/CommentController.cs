namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data;
    using H8QMedia.Web.Areas.Users.ViewModels.Comment;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.Comment;

    public class CommentController : BaseController
    {
        private ICommentsService commentsService;

        public CommentController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddComment(InputCommentViewModelCreate model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var comment = this.Mapper.Map<Comment>(model);
                comment.UserId = this.UserProfile.Id;

                comment = this.commentsService.AddNew(comment);

                var viewModel = this.Mapper.Map<CommentViewModel>(comment);
                viewModel.UserName = this.UserProfile.UserName;

                return this.PartialView("~/Views/Comment/_SingleCommentPartial.cshtml", viewModel);
            }

            throw new HttpException(400, "Invalid Comment");
        }

        [Authorize]
        public ActionResult Delete(int id, int articleID)
        {
            this.commentsService.DeleteCommentById(id);

            return this.GetPageCommentsPartial(articleID);
        }

        public ActionResult GetPageCommentsPartial(int articleId)
        {
            var comments = this.commentsService
                .AllByEntity(articleId)
                .To<CommentViewModel>();

            return this.PartialView("_EntityCommentsPartial", comments);
        }
    }
}
