using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Pieces;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//TODO: Implement the check check function
//TODO: Check check after each turn
//TODO: Check checkmate
//TODO: Check stalemate

namespace ChessBackend
{
    public class Board
    {
        int width = 8;
        int height = 8;
        Cell[] cells = null;
        Piece[] all_pieces = null;
        King white_king = null;
        King black_king = null;

        public Board()
        {
            cells = new Cell[width * height];
            for (int i = 0; i < width * height; i++)
            {
                cells[i] = new Cell(i % width, i / width);
            }
            createPieces();
        }

        void createPieces()
        {
            all_pieces = new Piece[32];
            all_pieces[0] = new Rook();     //black rook left
            all_pieces[7] = new Rook();     //black rook right
            all_pieces[24] = new Rook();     //white rook left
            all_pieces[31] = new Rook();     //white rook right
            all_pieces[1] = new Knight();   //black knight left
            all_pieces[6] = new Knight();   //black knight right
            all_pieces[25] = new Knight();   //white knight left
            all_pieces[30] = new Knight();   //white knight right
            all_pieces[2] = new Bishop();   //black bishop left
            all_pieces[5] = new Bishop();   //black bishop right
            all_pieces[26] = new Bishop();   //white bishop left
            all_pieces[29] = new Bishop();   //white bishop right
            all_pieces[3] = new Queen();    //black queen
            all_pieces[28] = new Queen();    //white queen
            all_pieces[4] = new King();     //black king
            all_pieces[27] = new King();     //white king
            //all pawns
            for (int i = 8; i < 24; i++)
            {
                all_pieces[i] = new Pawn();
            }
            //init all values
            for (int i = 0; i < 16; i++)
            {
                all_pieces[i].init(Team.Black, getCell(i % 8, i / 8), this);
            }
            for (int i = 16; i < 32; i++)
            {
                all_pieces[i].init(Team.White, getCell(i % 8, 4 + (i / 8)), this);
            }
            //store kings to help identify when in check
            white_king = (King)all_pieces[27];
            black_king = (King)all_pieces[4];
        }

        public Cell getCell(int x, int y)
        {
            if (x > width)
            {
                Debug.printError("Cell out of X range");
                return null;
            }
            if (y > height)
            {
                Debug.printError("Cell out of Y range");
                return null;
            }
            return cells[(y * width) + x];
        }

        public bool checkPathBlocked(Cell from, Cell to)
        {
            //get path direction
            int x_dir = to.x_location - from.x_location;
            if (x_dir != 0)
                //normalises the direction
                x_dir = x_dir / Math.Abs(x_dir);
            int y_dir = to.y_location - from.y_location;
            if (y_dir != 0)
                //normalises the direction
                y_dir = y_dir / Math.Abs(y_dir);

            //check every cell in the direction
            int x = from.x_location + x_dir;
            int y = from.y_location + y_dir;
            //loop through the direction until you reach the target
            //wasn't working the normal way, so now here is an if statement
            if (y_dir == 0)
            {
                for (; x != to.x_location;
                    x += x_dir, y += y_dir)
                {
                    if (getCell(x, y).unit != null)
                    {
                        if (getCell(x, y).unit.board_a == from.unit.board_a)
                            return true;
                    }
                }
            }
            else
            {
                for (; y != to.y_location;
                    x += x_dir, y += y_dir)
                {
                    if (getCell(x, y).unit != null)
                        if (getCell(x, y).unit.board_a == from.unit.board_a)
                            return true;
                }
            }
            return false;
        }

        public void checkFeedback(Team active_player, ref string feedback)
        {
            if(inCheck(active_player) != null)
            {
                if(hasValidMoves(active_player))
                {
                    feedback = inCheck(active_player).id + " has you in check.";
                }
                else
                {
                    feedback = "Game over. " + (Team)(3 - active_player) + " wins!";
                }
            }
            else if(!hasValidMoves(active_player))
            {
                feedback = "The game has ended in a stalemate.";
            }
        }

        public Piece inCheck(Team team)
        {
            Piece my_king = team == Team.Black ? black_king : white_king;
            foreach (Piece piece in all_pieces)
            {
                if (piece.alive)
                {
                    if (piece.unit_team != team)
                    {
                        string n = "";
                        if (piece.validMove(my_king.unit_position, ref n))
                        {
                            return piece;
                        }
                    }
                }
            }
            return null;
        }

        public bool hasValidMoves(Team team)
        {
            for (int i = 0; i < all_pieces.Length; i++)
            {
                Piece piece = all_pieces[i];
                if (piece.unit_team == team)
                {
                    foreach (Cell cell in cells)
                    {
                        string s = "";
                        if (piece.validMove(cell, ref s))
                        {
                            //make a copy of this board
                            //move the piece to the place
                            //are you out of check?
                                return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
