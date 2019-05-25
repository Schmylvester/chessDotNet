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

        public override bool validMove(Cell new_cell, ref string feedback)
        {
            //check path blocked
            if (board.checkPathBlocked(unit_position, new_cell))
            {
                feedback = "The path is blocked";
                return false;
            }
            //check lateral movement
            if (((new_cell.x_location == unit_position.x_location) !=
                 (new_cell.y_location == unit_position.y_location)))
                return base.validMove(new_cell, ref feedback);
            feedback = "Rooks can move any number of spaces in a lateral direction";
            return false;
        }
    }
}
