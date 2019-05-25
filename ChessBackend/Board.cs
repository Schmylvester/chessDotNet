using System;
using System.Collections.Generic;
using System.Text;
using ChessBackend.Pieces;

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
            //white team
            allPieces[0] = new Rook();
            allPieces[1] = new Knight();
            allPieces[2] = new Bishop();
            allPieces[3] = new Queen();
            allPieces[4] = new King();
            allPieces[5] = new Bishop();
            allPieces[6] = new Knight();
            allPieces[7] = new Rook();
            //all pawns
            for (int i = 8; i < 24; i++)
            {
                allPieces[i] = new Pawn();
            }
            //black team
            allPieces[24] = new Rook();
            allPieces[25] = new Knight();
            allPieces[26] = new Bishop();
            allPieces[27] = new King();
            allPieces[28] = new Queen();
            allPieces[29] = new Bishop();
            allPieces[30] = new Knight();
            allPieces[31] = new Rook();
            //init all values
            for (int i = 0; i < 16; i++)
            {
                allPieces[i].init(Team.Black, getCell(i % 8, i / 8), this);
            }
            for (int i = 16; i < 32; i++)
            {
                allPieces[i].init(Team.White, getCell(i % 8, 4 + (i / 8)), this);
            }
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
                x_dir = x_dir / Math.Abs(x_dir);
            int y_dir = to.y_location - from.y_location;
            if (y_dir != 0)
                y_dir = y_dir / Math.Abs(y_dir);

            //check every cell in the direction
            int x;
            int y;
            for (x = from.x_location + x_dir, y = from.y_location + y_dir;
                x < to.x_location && y < to.y_location;
                x += x_dir, y += y_dir)
            {
                if (getCell(x, y).unit != null)
                    return true;
            }
            return false;
        }
    }
}
