using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Pieces
{
    class Pawn : Piece
    {
        public override string getName()
        {
            return "Pawn";
        }

        public override bool validMove(Cell new_cell)
        {
            //check which direction the pawn faces
            int direction = 0;
            if (unit_team == Team.Black)
                direction = 1;
            else
                direction = -1;
            SpaceOccupied in_space = checkSpaceBlocked(new_cell);
            if (unit_position.y_location + direction == new_cell.y_location)
            {
                //one space forward
                if (unit_position.x_location == new_cell.x_location && in_space == SpaceOccupied.Empty)
                    return base.validMove(new_cell);
                //diagonal take
                if (Math.Abs(unit_position.x_location - new_cell.x_location) == 1 && in_space == SpaceOccupied.Enemy)
                    return base.validMove(new_cell);
            }
            // you can move two
            if (!has_moved)
            {
                if (unit_position.y_location + (direction * 2) == new_cell.y_location)
                {
                    //check path blocked
                    if (board.checkPathBlocked(unit_position, new_cell))
                        return false;
                    if (unit_position.x_location == new_cell.x_location && in_space == SpaceOccupied.Empty)
                        return base.validMove(new_cell);
                }
            }
            return false;
        }
    }
}
