using CaptureTheTreasure.Infrastructure.Game;
using CaptureTheTreasure.Application.Game;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class GameModel : PageModel
{
    public Game CurrentGame { get; set; }

    public void OnGet()
    {
        GetOrCreateGame();
        CurrentGame.Start();

        string direction = Request.Query["direction"].ToString() ?? "";
        if (!CurrentGame.ObstacleWasHit && !CurrentGame.HasFinished)
        {
            CurrentGame.MovePlayer(direction);
            var gameEvents = new GameEvents();
            gameEvents.CollectTresure(CurrentGame);
            gameEvents.HitObstacle(CurrentGame);
        }
    }

    public void OnPost()
    {
        GetOrCreateGame();
        CurrentGame.Restart();
    }

    private string GetOrCreateGameHash()
    {
        var GameHash = HttpContext.Session.GetString("GameHash") ?? Guid.NewGuid().ToString();
        HttpContext.Session.SetString("GameHash", GameHash);
        return GameHash;
    }
    private void GetOrCreateGame()
    {
        var GameHash = GetOrCreateGameHash();
        Game? GameFromManager = GameManager.FindGame(GameHash);
        if (null == GameFromManager)
        {
            CurrentGame = new Game();
            GameManager.AddGame(CurrentGame, GameHash);
        }
        else
        {
            CurrentGame = GameFromManager;
        }
    }
}
