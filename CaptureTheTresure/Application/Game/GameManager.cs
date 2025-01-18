namespace CaptureTheTresure.Application.Game;
public static class GameManager
{
    public static Dictionary<string, Game> Games = new Dictionary<string, Game>();

    public static Game? FindGame(string gameHash)
    {
        if (!Games.ContainsKey(gameHash))
            return null;
        return Games[gameHash];
    }

    public static void AddGame(Game game, string hash)
    {
        Games.Add(hash, game);
    }
}
