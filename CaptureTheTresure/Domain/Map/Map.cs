namespace CaptureTheTresure.Domain.Map;

public class Map
{
    public static int Width = 10;
    public static int Height = 10;

    public bool IsInsideMap(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
