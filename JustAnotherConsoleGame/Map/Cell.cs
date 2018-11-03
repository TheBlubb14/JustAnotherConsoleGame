namespace JustAnotherConsoleGame.Map
{
    public class Cell
    {
        public CellType Type { get; private set; }

        public bool IsSolid()
        {
            return this.Type != CellType.Empty;
        }

        public Cell(CellType cellType)
        {
            this.Type = cellType;
        }
    }
}
