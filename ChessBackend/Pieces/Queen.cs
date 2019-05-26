using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Pieces
{
    class Queen : Piece
    {
        public override string getName()
        {
            return "Queen";
        }

        public override bool validMove(Cell new_cell, ref string feedback)
        {
            if ((Math.Abs(new_cell.x_location - unit_position.x_location) ==
                 Math.Abs(new_cell.y_location - unit_position.y_location) &&
                 Math.Abs(new_cell.x_location - unit_position.x_location) > 0)
                 ||
                 ((new_cell.x_location == unit_position.x_location) !=
                 (new_cell.y_location == unit_position.y_location)))
            {
                //check path blocked
                Piece block = board.checkPathBlocked(unit_position, new_cell);
                if (block != null)
                {
                    feedback = "The path is blocked by " + block.id;
                    return false;
                }
                return base.validMove(new_cell, ref feedback);
            }
            feedback = "Queens can move any number of spaces in a single direction, laterally or diagonally";
            return false;
        }
    }
}
