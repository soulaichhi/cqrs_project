using cqrs_project.Data;
using cqrs_project.Models;
using MediatR;

namespace cqrs_project.Features.Players.CreatePlayer
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly AppDbContext _db;
        public CreatePlayerCommandHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Name=request.Name, Level=request.Level};
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return player.Id;
        }
    }
}
