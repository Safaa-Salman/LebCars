using System;
using System.Threading.Tasks;
using Application.Ratings;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace API.SignalR
{
    public class RatingHub : Hub
    {
        private readonly IMediator _mediator;
        public RatingHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendRating(GiveRating.Command command)
        {
            var rating = await _mediator.Send(command);

            await Clients.Group(command.TargetId.ToString())
                .SendAsync("ReceiveRating", rating.Value);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var targetId = httpContext.Request.Query["targetId"];
            await Groups.AddToGroupAsync(Context.ConnectionId, targetId);
            var result = await _mediator.Send(new List.Query{TargetId = targetId});
            await Clients.Caller.SendAsync("LoadRatings", result.Value);
        }
    }
}