﻿using CaptureTheTresure.Domain.Position;

namespace CaptureTheTresure.Domain.GameObjects;

public class Treasure : HasPositionInterface
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool isCollected { get; set; } = false;

    public Treasure(int x, int y)
    {
        X = x;
        Y = y;
    }
}

