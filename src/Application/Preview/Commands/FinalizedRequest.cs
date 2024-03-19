using MediatR;

namespace OnlineApplicationSystem.Application.Preview.Commands;

public class FinalizedRequest : IRequest<int>
{
    public string Id { get; set; }
}