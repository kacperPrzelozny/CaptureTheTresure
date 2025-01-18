using CaptureTheTresure.Domain.GameObjects;
using CaptureTheTresure.Domain.Map;
using CaptureTheTresure.Infrastructure.Generator;

namespace CaptureTheTresure.Application.Game;

public class Game
{
    public List<Treasure> Tresures = new List<Treasure>();
    public List<Obstacle> Obstacles = new List<Obstacle>();
    public Player Player = new Player();
    public Map Map = new Map();
    public bool HasStarted = false;
    public bool HasFinished = false;

    public void Start()
    {
        if (HasStarted && !HasFinished)
        {
            return;
        }

        GenerateTresuresAndObstacles();
        HasStarted = true;
    }
    public void MovePlayer(string direction)
    {
        switch(direction)
        {
            case "up":
                if(Map.IsInsideMap(Player.X, Player.Y - 1))
                    Player.Move(Direction.Up);  
                break;
            case "down":
                if (Map.IsInsideMap(Player.X, Player.Y + 1))
                    Player.Move(Direction.Down);
                break;
            case "left":
                if (Map.IsInsideMap(Player.X - 1, Player.Y))
                    Player.Move(Direction.Left);
                break;
            case "right":
                if (Map.IsInsideMap(Player.X + 1, Player.Y))
                    Player.Move(Direction.Right);
                break;
            default:
                break;
        }
    }

    public void Restart()
    {
        Tresures.Clear();
        Obstacles.Clear();
        Player.Reset();
        HasStarted = false;
        HasFinished = false;

        Start();
    }

    private void GenerateTresuresAndObstacles()
    {
        var coordinateGenerator = new RandomCoordinateGenerator();
        var coordinates = coordinateGenerator.Generate();

        foreach (var (x, y) in coordinates)
        {
            if (Tresures.Count < 5)
            {
                Tresures.Add(new Treasure(x, y));
            }
            else
            {
                Obstacles.Add(new Obstacle(x, y));
            }
        }
    }
}
