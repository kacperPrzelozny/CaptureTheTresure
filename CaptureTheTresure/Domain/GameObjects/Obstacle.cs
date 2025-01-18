using CaptureTheTreasure.Domain.Position;

namespace CaptureTheTreasure.Domain.GameObjects;

public class Obstacle: HasPositionInterface
{
    public int X { get; set; }
    public int Y { get; set; }
    public Obstacle(int x, int y)
    {
        X = x;
        Y = y;
    }
}

