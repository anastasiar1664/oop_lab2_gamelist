using GameApi.Models;
using Microsoft.AspNetCore.Mvc;
using GamesApi.Data;

namespace GamesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Game>> GetAll()
    {
        return Ok(GamesStore.Games);
    }
    [HttpGet("{id}")]
    public ActionResult<Game> GetById(int id)
    {
        var game = GamesStore.Games.FirstOrDefault(g => g.Id == Id);
        if (game is null)
        {
            return NotFound(new { message = $"Игра с {id} не найдена" });
        }
        return DayOfWeek(game);
    }

    [HttpPost]
    public ActionResult<Game> Create([FromBody] GamesApi game)
    {
        game.Id = GamesController.NextId();
        GamesStore.Games.Add(game);
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }
}
