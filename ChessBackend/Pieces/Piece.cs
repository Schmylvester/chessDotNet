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
            has_moved = false;
            board = _board;
            unit_team = team;
            unit_position = cell;
            cell.unit = this;
        }

        public virtual bool validMove(Cell new_cell, ref string feedback)
        {
            //check teammate in cell
            if (checkSpaceBlocked(new_cell) == SpaceOccupied.Ally)
            {
                feedback = "That space is occupied";
                return false;
            }
            //TODO: check whether move would put self in check
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
            unit_position.unit = null;
            unit_position = new_cell;
            new_cell.unit = this;
            has_moved = true;

            Team check = board.checkCheck();
            if (check != Team.None)
            {
                feedback = check + " is in check";
            }
        }
    }
}
