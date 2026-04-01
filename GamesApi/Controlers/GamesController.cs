using GamesApi.Models;
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
        return Ok(GameStore.Games);
    }
    [HttpGet("{id}")]
    public ActionResult<Game> GetById(int id)
    {
        var game = GameStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null)
        {
            return NotFound(new { message = $"Игра с {id} не найдена" });
        }
        return Ok(game);
    }

    [HttpPost]
    public ActionResult<Game> Create([FromBody] Game game)
    {
        game.Id = GameStore.NextId();
        GameStore.Games.Add(game);
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var game = GameStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null)
        {
            return NotFound(new { message = $"Игра с id = {id} не найдена" });
        }
        GameStore.Games.Remove(game);
        return NoContent();
    }

    [HttpPut("{id}")]
    public ActionResult<Game> Update(int id, [FromBody] Game updated)
    {
        var game = GameStore.Games.FirstOrDefault(g => g.Id == id);
        if (game is null)
        {
            return NotFound(new { message = $"Игра с id = {id} не найдена" });
        }
        game.Title = updated.Title;
        game.Genre = updated.Genre;
        game.ReleaseYear = updated.ReleaseYear;
        return Ok(game);
    }
}