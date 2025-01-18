using CaptureTheTreasure.Application.Game;

namespace CaptureTheTreasure.Infrastructure.Game;
public class GameEvents : GameEventsInterface
{
    public void CollectTresure(Application.Game.Game Game)
    {
        for (int i = 0; i < Game.Tresures.Count; i++)
        {
            var Treasure = Game.Tresures[i];
            if (checkIfSamePosition(Game.Player.X, Game.Player.Y, Treasure.X, Treasure.Y))
            {
                Game.Tresures.Remove(Treasure);
                Game.Player.IncrementScore();
                break;
            }
        }

        if (0 == Game.Tresures.Count)
        {
            Game.HasFinished = true;
        }
    }

    public void HitObstacle(Application.Game.Game Game)
    {
        for (int i = 0; i < Game.Obstacles.Count; i++)
        {
            var Obstacle = Game.Obstacles[i];
            if (checkIfSamePosition(Game.Player.X, Game.Player.Y, Obstacle.X, Obstacle.Y))
            {
                Game.ObstacleWasHit = true;
                Game.HasFinished = true;
                break;

            }
        }
    }

    private bool checkIfSamePosition(int x1, int y1, int x2, int y2)
    {
        return x1 == x2 && y1 == y2;
    }
}
