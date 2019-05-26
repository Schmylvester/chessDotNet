using System;
using System.Collections.Generic;
using System.Text;

public enum Transform
{
    None,
    Knight,
    Queen,
}

namespace ChessBackend.Pieces
{
    class Pawn : Piece
    {
        public Transform has_transformed = Transform.None;

        public override string getName()
        {
            return "Pawn";
        }

        public override bool validMove(Cell new_cell, ref string feedback)
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
                    return base.validMove(new_cell, ref feedback);
                //diagonal take
                if (Math.Abs(unit_position.x_location - new_cell.x_location) == 1 && in_space == SpaceOccupied.Enemy)
                    return base.validMove(new_cell, ref feedback);
            }
            // you can move two
            if (!has_moved)
            {
                if (unit_position.y_location + (direction * 2) == new_cell.y_location
                    && unit_position.x_location == new_cell.x_location && in_space == SpaceOccupied.Empty)
                {
                    //check path blocked
                    Piece block = board.checkPathBlocked(unit_position, new_cell);
                    if (block != null)
                    {
                        feedback = "This would be valid if you were not trying to jump over the " + block.id;
                        return false;
                    }
                    return base.validMove(new_cell, ref feedback);
                }
            }
            feedback = "Pawns have a bunch of movement rules, that move would break them";
            return false;
        }

        public override void move(Cell new_cell, ref string feedback)
        {
            if(new_cell.y_location == 0 || new_cell.y_location == 7)
            {
                transformPiece(Transform.Queen, new_cell, ref feedback);
                return;
            }
            base.move(new_cell, ref feedback);
        }

        public void transformPiece(Transform into, Cell new_cell, ref string feedback)
        {
            int my_idx = -1;
            //find me on the board
            for (int i = 0; i < 32; i++)
            {
                if (board.all_pieces[i] == this)
                {
                    my_idx = i;
                    break;
                }
            }
            //transform me
            Piece me = null;
            if (into == Transform.Queen)
                me = new Queen();
            else
                me = new Knight();
            makeCopy(me, board);
            me.move(new_cell, ref feedback);
            board.all_pieces[my_idx] = me;
            has_transformed = into;
        }
    }
}
