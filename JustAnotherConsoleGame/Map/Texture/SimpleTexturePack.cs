using System.Collections.Generic;

namespace JustAnotherConsoleGame.Map.Texture
{
    public class SimpleTexturePack : ITexturePack
    {
        private static Dictionary<CellType, char> CellMap = new Dictionary<CellType, char>()
        {
            {CellType.WallVertical, '│' },
            {CellType.WallHorizontal, '─'},

            {CellType.CornerBottomLeft, '┐'},
            {CellType.CornerBottomRight, '┌'},
            {CellType.CornerTopLeft, '┘'},
            {CellType.CornerTopRight, '└'},

            {CellType.Intersection, '┼'},
            {CellType.TBottom, '┬'},
            {CellType.TTop, '┴'},
            {CellType.TLeft, '┤'},
            {CellType.TRight, '├'},

            {CellType.Empty, ' ' }
        };

        public char this[CellType? index] => CellMap[index ?? CellType.Empty];
    }
}
