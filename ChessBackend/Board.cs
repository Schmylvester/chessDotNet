using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Pieces;

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
        Piece[] allPieces = null;
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
            allPieces = new Piece[32];
            allPieces[0] = new Rook();     //black rook left
            allPieces[7] = new Rook();     //black rook right
            allPieces[24] = new Rook();     //white rook left
            allPieces[31] = new Rook();     //white rook right
            allPieces[1] = new Knight();   //black knight left
            allPieces[6] = new Knight();   //black knight right
            allPieces[25] = new Knight();   //white knight left
            allPieces[30] = new Knight();   //white knight right
            allPieces[2] = new Bishop();   //black bishop left
            allPieces[5] = new Bishop();   //black bishop right
            allPieces[26] = new Bishop();   //white bishop left
            allPieces[29] = new Bishop();   //white bishop right
            allPieces[3] = new Queen();    //black queen
            allPieces[28] = new Queen();    //white queen
            allPieces[4] = new King();     //black king
            allPieces[27] = new King();     //white king
            //all pawns
            for (int i = 8; i < 24; i++)
            {
                allPieces[i] = new Pawn();
            }
            //init all values
            for (int i = 0; i < 16; i++)
            {
                allPieces[i].init(Team.Black, getCell(i % 8, i / 8), this);
            }
            for (int i = 16; i < 32; i++)
            {
                allPieces[i].init(Team.White, getCell(i % 8, 4 + (i / 8)), this);
            }
            //store kings to help identify when in check
            white_king = (King)allPieces[27];
            black_king = (King)allPieces[4];
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
            int x;
            int y;
            for (x = from.x_location + x_dir, y = from.y_location + y_dir;
                x != to.x_location && y != to.y_location;
                x += x_dir, y += y_dir)
            {
                if(Math.Abs(x) >= 8 || Math.Abs(y) >= 8)
                {
                    Debug.printError("Problem with the path check loop");
                    return false;
                }
                if (getCell(x, y).unit != null)
                    return true;
            }
            return false;
        }

        public bool checkCheck()
        {
            return false;
        }
    }
}
