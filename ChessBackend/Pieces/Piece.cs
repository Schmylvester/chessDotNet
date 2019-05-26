using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBackend
{
    public enum Team
    {
        None,
        Black,
        White,

        Both,
    }

    public abstract class Piece
    {
        public enum SpaceOccupied
        {
            Ally,
            Enemy,
            Empty,
        }
        protected Board board = null;
        public Team unit_team { get; set; }
        public bool has_moved { get; set; }
        public Cell unit_position { get; set; }
        public bool board_a { get; set; }
        public bool alive { get; set; }
        public string id
        {
            get
            {
                return unit_team.ToString() + " " + getName();
            }
        }

        public abstract string getName();

        public void init(Team team, Cell cell, Board _board)
        {
            alive = true;
            board_a = true;
            has_moved = false;
            board = _board;
            unit_team = team;
            unit_position = cell;
            cell.unit = this;
        }

        public virtual bool validMove(Cell new_cell, ref string feedback)
        {
            //check alternate cell is blocked
            Piece unit = new_cell.unit;
            if (unit != null)
            {
                if (unit.board_a != board_a)
                {
                    feedback = "That space is occupied in the other dimension";
                    return false;
                }
            }
            //check teammate in cell
            if (checkSpaceBlocked(new_cell) == SpaceOccupied.Ally)
            {
                feedback = "That space is occupied";
                return false;
            }
            //check whether move puts self in check
            Board copy = board.makeCopy();
            Piece unit_copy = copy.getCell(unit_position.x_location, unit_position.y_location).unit;
            string s = "";
            unit_copy.move(copy.getCell(new_cell.x_location, new_cell.y_location), ref s);
            if(copy.inCheck(unit_team) != null)
            {
                feedback = "If I let you do that, you would end your turn in check";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks a target cell for whether it holds a unit and which team they're on
        /// </summary>
        /// <param name="new_cell">The cell to which this unit intends to move</param>
        /// <returns>What is in the target cell</returns>
        protected SpaceOccupied checkSpaceBlocked(Cell new_cell)
        {
            if (new_cell.unit != null)
            {
                if (new_cell.unit.unit_team == unit_team)
                {
                    return SpaceOccupied.Ally;
                }
                return SpaceOccupied.Enemy;
            }
            return SpaceOccupied.Empty;
        }

        public void move(Cell new_cell, ref string feedback)
        {
            if (new_cell.unit != null)
            {
                new_cell.unit.alive = false;
            }
            unit_position.unit = null;
            unit_position = new_cell;
            new_cell.unit = this;
            has_moved = true;
            board_a = !board_a;
        }

        public void makeCopy(Piece copy_to, Board their_board)
        {
            copy_to.alive = alive;
            copy_to.board_a = board_a;
            copy_to.board = their_board;
            copy_to.has_moved = has_moved;
            copy_to.unit_position = their_board.getCell(unit_position.x_location, unit_position.y_location);
            copy_to.unit_team = unit_team;
            if(copy_to.alive)
                copy_to.unit_position.unit = copy_to;
        }
    }
}
