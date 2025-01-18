namespace CaptureTheTreasure.Infrastructure.Generator;

public class RandomCoordinateGenerator
{
    public List<(int, int)> Generate()
    {
        var coordinates = new HashSet<(int, int)>();

        Random rand = new Random();

        while (coordinates.Count < 10)
        {
            int x = rand.Next(1, 9);
            int y = rand.Next(1, 9);
            coordinates.Add((x, y));
        }

        return new List<(int, int)>(coordinates);
    }
}
