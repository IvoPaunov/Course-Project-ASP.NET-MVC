namespace H8QMedia.Web.Areas.Users.Controllers
{
    using System.Web.Mvc;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;
    using H8QMedia.Web.Areas.Users.ViewModels.Message;
    using H8QMedia.Web.Controllers;

    public class MessageController : BaseController
    {
        private IMessagesService messageService;

        public MessageController(IMessagesService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        public ActionResult Send(MessageInputModelCreate model)
        {
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MessageInputModelCreate model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var newMessage = this.Mapper.Map<Message>(model);

                newMessage.SenderId = this.UserProfile.Id;

                var result = this.messageService.AddMessage(newMessage);

                return this.RedirectToAction("Index", "Profile", new { area = "Users" });
            }

            return this.View(model);
        }
    }
}