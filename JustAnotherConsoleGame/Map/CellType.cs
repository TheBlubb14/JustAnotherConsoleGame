namespace JustAnotherConsoleGame.Map
{
    public enum CellType
    {
        WallVertical,
        WallHorizontal,
        Wall = WallVertical | WallHorizontal,

        CornerBottomLeft,
        CornerBottomRight,
        CornerTopLeft,
        CornerTopRight,
        CornerTop = CornerTopLeft | CornerTopRight,
        CornerBottom = CornerBottomLeft | CornerBottomRight,
        Cornrer = CornerBottom | CornerTop,

        Intersection,
        TBottom,
        TTop,
        TLeft,
        TRight,
        T = TBottom | TTop | TLeft | TRight,

        Empty
    }
}
