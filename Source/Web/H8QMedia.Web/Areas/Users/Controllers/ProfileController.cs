namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Areas.Users.ViewModels.Message;
    using H8QMedia.Web.Controllers;
    using H8QMedia.Web.Infrastructure.Mapping;
    using H8QMedia.Web.ViewModels.User;

    [Authorize]
    public class ProfileController : BaseController
    {
        private IMessagesService messages;
        private IUsersService users;

        public ProfileController(IMessagesService messages, IUsersService users)
        {
            this.messages = messages;
            this.users = users;
        }

        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult Username(string id)
        {
            var model = this.users.GetUser(id)
                .To<UserViewModel>()
                .FirstOrDefault();

            return View("PublicProfile", model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetUserProfilePartial()
        {
            var userName = this.UserProfile.UserName;

            var userData =
                this.Cache.Get(
                    userName,
                    () => this.users
                        .UserById(this.UserProfile.Id)
                        .To<UserViewModel>()
                        .FirstOrDefault(),
                    1 * 60);

            return this.PartialView("_UserProfilePartial", userData);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetInboxMessagesPartial()
        {
            var model = this.messages
                .AllToUserId(this.UserProfile.Id)
                .To<MessageViewModel>();

            return this.PartialView("_InboxMessagesPartial", model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetOutboxMessagesPartial()
        {
            var model = this.messages
                .AllFromUserId(this.UserProfile.Id)
                .To<MessageViewModel>();

            return this.PartialView("_OutboxMessagesPartial", model);
        }

        [Authorize]
        public ActionResult Update(int id)
        {
            this.messages.MarkAsSeen(id);

            return this.GetInboxMessagesPartial();
        }
    }
}
