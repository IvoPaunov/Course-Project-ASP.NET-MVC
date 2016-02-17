namespace H8QMedia.Web.Areas.Users.ViewModels.Message
{
    using System;
    using AutoMapper;
    using H8QMedia.Data.Models;
    using H8QMedia.Web.Infrastructure.Mapping;

    public class MessageViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string SenderName { get; set; }

        public string SenderId { get; set; }

        public bool IsSeen { get; set; }

        public string RecipientName { get; set; }

        public string RecipientId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Message, MessageViewModel>()
                .ForMember(u => u.SenderName, opts => opts.MapFrom(u => u.Sender.UserName))
                .ForMember(u => u.RecipientName, opts => opts.MapFrom(u => u.Recipient.UserName));
        }
    }
}
