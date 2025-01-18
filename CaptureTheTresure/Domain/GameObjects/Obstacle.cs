using CaptureTheTresure.Domain.Position;

namespace CaptureTheTresure.Domain.GameObjects;

public class Obstacle: HasPositionInterface, HasRandomPositionInterface
{
    public int X { get; set; }
    public int Y { get; set; }
    public void rollPosition()
    {
        X = new Random().Next(1, 10);
        Y = new Random().Next(1, 10);
    }
}

