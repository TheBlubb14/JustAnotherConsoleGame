using JustAnotherConsoleGame.Map;
using System;
using System.Drawing;

namespace JustAnotherConsoleGame
{
    public class Player
    {
        public char Icon { get; private set; }

        public Point Position => this.position;

        private Point position;
        private Point oldPosition;

        private MapGenerator map;

        public Player(char icon, Point position, MapGenerator map)
        {
            this.Icon = icon;
            this.position = position;
            this.map = map;

            Console.SetCursorPosition(map.Offset.X + this.Position.X, map.Offset.Y + this.Position.Y);
            Console.Write(this.Icon);
        }

        private void UpdatePosition(int dx, int dy)
        {
            var newLocation = new Point(this.Position.X + dx, this.Position.Y + dy);
            if (this.CheckMove(newLocation))
            {
                this.UpdatePosition(newLocation);
                this.Draw();
            }
        }

        private void UpdatePosition(Point position)
        {
            this.oldPosition = this.Position;
            this.position = position;
        }

        private void Draw()
        {
            Console.MoveBufferArea(this.map.Offset.X + this.oldPosition.X, this.map.Offset.Y + this.oldPosition.Y, 1, 1, this.map.Offset.X + this.Position.X, this.map.Offset.Y + this.Position.Y);
        }

        public void MooveLeft()
        {
            this.UpdatePosition(-1, 0);
            Console.Title = "left " + this.Position.ToString();
        }

        public void MooveRight()
        {
            this.UpdatePosition(+1, 0);
            Console.Title = "right " + this.Position.ToString();
        }

        public void MooveUp()
        {
            this.UpdatePosition(0, -1);
            Console.Title = "up " + this.Position.ToString();
        }

        public void MooveDown()
        {
            this.UpdatePosition(0, +1);
            Console.Title = "down " + this.Position.ToString();
        }

        public bool CheckMove(Point newPosition)
        {
            return this.map.CheckValidMoove(newPosition);

            // TODO: playground über map api / interface bekommen

            // TODO: checkmoove durch map überprüfen lassen, und hier einfach nur aufrufen
            if (newPosition.X < 0 || newPosition.Y < 0)
                return false;
            else
                return true;
        }
    }
}
