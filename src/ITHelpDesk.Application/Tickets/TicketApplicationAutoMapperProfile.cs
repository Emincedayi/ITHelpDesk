using AutoMapper;
using ITHelpDesk.Comments;
using ITHelpDesk.Tickets;

namespace ITHelpDesk
{
    public class TicketApplicationAutoMapperProfile : Profile
    {
        public TicketApplicationAutoMapperProfile()
        {
            CreateMap<Ticket, TicketDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}
