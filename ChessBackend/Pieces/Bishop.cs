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
            //check diagonal movement
            if (Math.Abs(new_cell.x_location - unit_position.x_location) ==
                 Math.Abs(new_cell.y_location - unit_position.y_location) &&
                 Math.Abs(new_cell.x_location - unit_position.x_location) > 0)
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
            feedback = "Bishops can move any number of spaces diagonally";
            return false;
        }
    }
}
