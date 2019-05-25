using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Pieces
{
    class Rook : Piece
    {
        public override string getName()
        {
            return "Rook";
        }

        public override bool validMove(Cell new_cell)
        {
            //check path blocked
            if (board.checkPathBlocked(unit_position, new_cell))
                return false;
            //check lateral movement
            if (((new_cell.x_location == unit_position.x_location) !=
                 (new_cell.y_location == unit_position.y_location)))
                return base.validMove(new_cell);
            return false;
        }
    }
}
