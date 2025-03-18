using cqrs_project.Data;
using cqrs_project.Features.Players.CreatePlayer;
using cqrs_project.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace cqrs_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly ISender _sender;
        public PlayersAPIController(AppDbContext db, ISender sender)
        {
            _db = db;
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command) {
            var playerId = await _sender.Send(command);
      
            return Ok(playerId);
        }
    }
}
