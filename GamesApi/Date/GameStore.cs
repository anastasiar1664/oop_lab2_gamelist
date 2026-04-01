using GamesApi.Models;
using Microsoft.VisualBasic;
namespace GamesApi.Data;

public static class GameStore
{
    private static int _nextId = 5;
    public static List<Game> Games { get; } = new()
    {
        new Game
        {
            Id = 1,
            Title = "Onmyoji",
            Genre = "RPG",
            ReleaseYear = 2018
        },
        new Game
        {
            Id = 2,
            Title = "Dota 2",
            Genre = "MOBA",
            ReleaseYear = 2013
        },
        new Game
        {
            Id = 3,
            Title = "Cookie Run: Kingdom",
            Genre = "RPG",
            ReleaseYear = 2021
        },
        new Game
        {
            Id = 4,
            Title = "Zenless Zone Zero",
            Genre = "Action-RPG",
            ReleaseYear = 2024
        },
    };
    public static int NextId() => _nextId++;
}