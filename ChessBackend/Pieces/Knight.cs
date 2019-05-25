using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Pieces
{
    class Knight : Piece
    {
        public override string getName()
        {
            return "Knight";
        }

        public override bool validMove(Cell new_cell, ref string feedback)
        {
            if ((Math.Abs(new_cell.x_location - unit_position.x_location) == 1
                && Math.Abs(new_cell.y_location - unit_position.y_location) == 2)
            || (Math.Abs(new_cell.x_location - unit_position.x_location) == 2
            && Math.Abs(new_cell.y_location - unit_position.y_location) == 1))
                return base.validMove(new_cell, ref feedback);
            feedback = "Knights can move two spaces in a direction and one space in a perpendicular direction";
            return false;
        }
    }
}
