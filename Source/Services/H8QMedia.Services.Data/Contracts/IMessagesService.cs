namespace H8QMedia.Services.Data.Contracts
{
    using System.Linq;
    using H8QMedia.Data.Models;

    public interface IMessagesService
    {
        IQueryable<Message> AllToUserId(string id);

        IQueryable<Message> AllFromUserId(string id);

        Message AddMessage(Message toAdd);

        void MarkAsSeen(int id);
    }
}
