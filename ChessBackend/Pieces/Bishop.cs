using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Pieces
{
    class Bishop : Piece
    {
        public override string getName()
        {
            return "Bishop";
        }

        public override bool validMove(Cell new_cell, ref string feedback)
        {
            //check path blocked
            if (board.checkPathBlocked(unit_position, new_cell))
            {
                feedback = "The path is blocked";
                return false;
            }
            //check diagonal movement
            if (Math.Abs(new_cell.x_location - unit_position.x_location) ==
                 Math.Abs(new_cell.y_location - unit_position.y_location) &&
                 Math.Abs(new_cell.x_location - unit_position.x_location) > 0)
                return base.validMove(new_cell, ref feedback);
            feedback = "Bishops can move any number of spaces diagonally";
            return false;
        }
    }
}
