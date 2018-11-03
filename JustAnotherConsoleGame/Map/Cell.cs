using System;
using System.Collections.Generic;
using System.Text;

namespace JustAnotherConsoleGame.Map
{
    public class Cell
    {
        public CellType Type { get; private set; }

        public Cell(CellType cellType)
        {
            this.Type = cellType;
        }
    }
}
