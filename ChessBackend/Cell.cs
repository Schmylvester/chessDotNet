using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend
{
    public class Cell
    {
        public Piece unit = null;
        public int x_location { get; set; }
        public int y_location { get; set; }

        public Cell(int x, int y)
        {
            x_location = x;
            y_location = y;
        }
    }
}
