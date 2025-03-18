using MediatR;

namespace cqrs_project.Features.Players.CreatePlayer
{
    public record CreatePlayerCommand(string Name, int Level) : IRequest<int>;
    
}
