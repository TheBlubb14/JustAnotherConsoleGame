using JustAnotherConsoleGame.Map;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace JustAnotherConsoleGame
{
    public partial class MapGenerator
    {
        Dictionary<CellType, char> Cells = new Dictionary<CellType, char>()
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

        public int Width { get; private set; }

        public int Height { get; private set; }

        public Point SpawnPoint => new Point(this.Width / 2, this.Height / 2);

        private Cell[,] Map;

        public MapGenerator(int width, int height)
        {
            this.Height = height;
            this.Width = width;

            this.Map = new Cell[width, height];


            for (int i = 0; i < width - 1; i++)
            {
                this.Map[i, 0] = new Cell(CellType.WallHorizontal);
                this.Map[i, height - 1] = new Cell(CellType.WallHorizontal);
            }

            for (int i = 0; i < width - 1; i++)
            {
                this.Map[0, i] = new Cell(CellType.WallVertical);
                this.Map[width - 1, i] = new Cell(CellType.WallVertical);
            }

            this.Map[0, 0] = new Cell(CellType.CornerBottomRight);
            this.Map[width - 1, 0] = new Cell(CellType.CornerBottomLeft);

            this.Map[0, height - 1] = new Cell(CellType.CornerTopRight);
            this.Map[width - 1, height - 1] = new Cell(CellType.CornerTopLeft);
        }

        public void Draw()
        {
            for (int y = 0; y < this.Map.GetLength(1); y++)
            {
                string line = "";
                for (int x = 0; x < this.Map.GetLength(0); x++)
                {
                    line += this.Cells[this.Map[x, y]?.Type ?? CellType.Empty];
                }
                Console.WriteLine(line);
            }
        }

        public bool CheckValidMoove(Point newPosition)
        {
            if ((this.Map[newPosition.X, newPosition.Y]?.Type ?? CellType.Empty) == CellType.Empty)
                return true;
            else
                return false;
        }
    }
}
