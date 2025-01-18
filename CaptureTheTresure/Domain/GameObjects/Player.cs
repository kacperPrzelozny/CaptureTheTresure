using CaptureTheTresure.Domain.Position;

namespace CaptureTheTresure.Domain.GameObjects;

public class Player : HasPositionInterface
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public string Name { get; set; }
    public int Score { get; set; } = 0;

    public void Move(Direction d)
    {
        if (d == Direction.Up)
        {
            Y--;
        }
        else if (d == Direction.Down)
        {
            Y++;
        }
        else if (d == Direction.Left)
        {
            X--;
        }
        else if (d == Direction.Right)
        {
            X++;
        }
    }
}

