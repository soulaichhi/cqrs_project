using cqrs_project.Data;
using cqrs_project.Models;
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
        public PlayersAPIController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(Player player) {
            _db.Players.Add(player);
            await _db.SaveChangesAsync();
            return Ok(player.Id);
        }
    }
}
