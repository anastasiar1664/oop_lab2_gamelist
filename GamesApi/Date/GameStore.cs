using GameApi.Models;
using Microsoft.VisualBasic;
namespace GamesApi.Data;
public static class GameStore
{
    private static int _nextId = 4;
    public static List<Game> Games { get; } = new()
    {
        new Game
        {
            Id = 1,
            Title = "Onmyoji",
            Genre = "RPG",
            Year = 2018
        },
        new Game
        {
            Id = 2,
            Title = "Dota 2",
            Genre = "MOBA",
            Year = 2013
        },
        new Game
        {
            Id = 3,
            Title = "Cookie Run: Kingdom",
            Genre = "RPG",
            Year = 2021
        },
        new Game
        {
            Id = 4,
            Title = "Zenless Zone Zero",
            Genre = "Action-RPG",
            Year = 2024
        },
    };
    public static int NextId() => _nextId++;
}