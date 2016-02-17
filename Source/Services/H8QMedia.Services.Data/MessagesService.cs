namespace H8QMedia.Services.Data
{
    using System.Linq;
    using H8QMedia.Data.Common.Repositories;
    using H8QMedia.Data.Models;
    using H8QMedia.Services.Data.Contracts;

    public class MessagesService : IMessagesService
    {
        private readonly IDbRepository<Message, int> messages;

        public MessagesService(IDbRepository<Message, int> messages)
        {
            this.messages = messages;
        }

        public IQueryable<Message> AllToUserId(string id)
        {
            return this.messages.All()
               .Where(m => m.RecipientId == id && m.IsSeen == false)
               .OrderByDescending(m => m.CreatedOn);
        }

        public IQueryable<Message> AllFromUserId(string id)
        {
            return this.messages.All()
               .Where(m => m.SenderId == id)
               .OrderByDescending(m => m.CreatedOn);
        }

        public Message AddMessage(Message toAdd)
        {
            this.messages.Add(toAdd);
            this.messages.Save();

            return toAdd;
        }

        public void MarkAsSeen(int id)
        {
            var messageToUpdate = this.messages.GetById(id);

            if (messageToUpdate != null)
            {
                messageToUpdate.IsSeen = true;

                this.messages.Save();
            }
        }
    }
}
