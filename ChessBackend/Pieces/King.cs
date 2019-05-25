using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend.Pieces
{
    class King : Piece
    {
        public override string getName()
        {
            return "King";
        }

        public override bool validMove(Cell new_cell, ref string feedback)
        {
            //new cell is one space away
            if (Math.Abs(new_cell.x_location - unit_position.x_location) == 1
                || Math.Abs(new_cell.y_location - unit_position.y_location) == 1)
                return base.validMove(new_cell, ref feedback);
            if (checkCastling())
                return base.validMove(new_cell, ref feedback);
            feedback = "A king can move one space in any direction, and there is a castling rule which that did not satisfy";
            return false;
        }

        /*
         * TODO: implement stupid niche rule that
         * people only ever do to demonstate that
         * they understand the stupid rule and 
         * is never done to provide actual tactical
         * advantages in the game despite their
         * insistence to the contrary
         */
        private bool checkCastling()
        {
            //check direction is two in the x
            //get appropriate castle
            //check path to that castle
            //check neither has moved
            //check it's not in check
            //check it wouldn't be
                //it valid
            return false;
        }
    }
}
