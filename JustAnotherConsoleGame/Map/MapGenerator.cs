using JustAnotherConsoleGame.Map.Texture;
using System;
using System.Drawing;

namespace JustAnotherConsoleGame.Map
{
    public class MapGenerator
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public ITexturePack TexturePack { get; private set; }

        public Point SpawnPoint => new Point(this.Width / 2, this.Height / 2);

        private Cell[,] Map;

        public MapGenerator(int width, int height, ITexturePack texturePack)
        {
            this.Height = height;
            this.Width = width;
            this.TexturePack = texturePack;

            this.Map = new Cell[width, height];

            #region Corners
            this.Map[0, 0] = new Cell(CellType.CornerBottomRight);
            this.Map[width - 1, 0] = new Cell(CellType.CornerBottomLeft);

            this.Map[0, height - 1] = new Cell(CellType.CornerTopRight);
            this.Map[width - 1, height - 1] = new Cell(CellType.CornerTopLeft);
            #endregion 

            #region Borders

            for (int i = 1; i < width - 1; i++)
            {
                this.Map[i, 0] = new Cell(CellType.WallHorizontal);
                this.Map[i, height - 1] = new Cell(CellType.WallHorizontal);
            }

            for (int i = 1; i < Height - 1; i++)
            {
                this.Map[0, i] = new Cell(CellType.WallVertical);
                this.Map[width - 1, i] = new Cell(CellType.WallVertical);
            }
            #endregion 
        }

        public void Draw()
        {
            for (int y = 0; y < this.Map.GetLength(1); y++)
            {
                string line = "";
                for (int x = 0; x < this.Map.GetLength(0); x++)
                {
                    line += this.TexturePack[this.Map[x, y]?.Type ?? CellType.Empty];
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
