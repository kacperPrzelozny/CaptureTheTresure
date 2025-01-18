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

    // private methods

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
