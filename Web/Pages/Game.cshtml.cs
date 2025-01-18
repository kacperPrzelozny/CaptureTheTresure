using CaptureTheTresure.Application.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages;

public class GameModel : PageModel
{
    public Game CurrentGame { get; set; }

    public void OnGet()
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
        CurrentGame.Start();

        string direction = Request.Query["direction"].ToString() ?? "";
        CurrentGame.MovePlayer(direction);

    }
    private string GetOrCreateGameHash()
    {
        var GameHash = HttpContext.Session.GetString("GameHash") ?? Guid.NewGuid().ToString();
        HttpContext.Session.SetString("GameHash", GameHash);
        return GameHash;
    }
}
