using System.Windows.Forms;
using ChessBackend;

namespace ChessNet
{
    public partial class ChessBoard : Form
    {
        Board board;
        Button[,] cells;
        public ChessBoard()
        {
            InitializeComponent();
            linkButtons();
            //get the pieces from the board
            board = new Board();
            updateBoard();
        }

        void updateBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (board.getCell(x, y).unit == null)
                    {
                        cells[x, y].Text = "";
                    }
                    else
                    {
                        cells[x, y].Text = board.getCell(x, y).unit.id;
                    }
                }
            }
        }

        void linkButtons()
        {
            //TODO: there is definitely a better way to do this, find it

            cells = new Button[8, 8];
            cells[0, 0] = x0y0; cells[1, 0] = x1y0;
            cells[2, 0] = x2y0; cells[3, 0] = x3y0;
            cells[4, 0] = x4y0; cells[5, 0] = x5y0;
            cells[6, 0] = x6y0; cells[7, 0] = x7y0;

            cells[0, 1] = x0y1; cells[1, 1] = x1y1;
            cells[2, 1] = x2y1; cells[3, 1] = x3y1;
            cells[4, 1] = x4y1; cells[5, 1] = x5y1;
            cells[6, 1] = x6y1; cells[7, 1] = x7y1;

            cells[0, 2] = x0y2; cells[1, 2] = x1y2;
            cells[2, 2] = x2y2; cells[3, 2] = x3y2;
            cells[4, 2] = x4y2; cells[5, 2] = x5y2;
            cells[6, 2] = x6y2; cells[7, 2] = x7y2;

            cells[0, 3] = x0y3; cells[1, 3] = x1y3;
            cells[2, 3] = x2y3; cells[3, 3] = x3y3;
            cells[4, 3] = x4y3; cells[5, 3] = x5y3;
            cells[6, 3] = x6y3; cells[7, 3] = x7y3;

            cells[0, 4] = x0y4; cells[1, 4] = x1y4;
            cells[2, 4] = x2y4; cells[3, 4] = x3y4;
            cells[4, 4] = x4y4; cells[5, 4] = x5y4;
            cells[6, 4] = x6y4; cells[7, 4] = x7y4;

            cells[0, 5] = x0y5; cells[1, 5] = x1y5;
            cells[2, 5] = x2y5; cells[3, 5] = x3y5;
            cells[4, 5] = x4y5; cells[5, 5] = x5y5;
            cells[6, 5] = x6y5; cells[7, 5] = x7y5;

            cells[0, 6] = x0y6; cells[1, 6] = x1y6;
            cells[2, 6] = x2y6; cells[3, 6] = x3y6;
            cells[4, 6] = x4y6; cells[5, 6] = x5y6;
            cells[6, 6] = x6y6; cells[7, 6] = x7y6;

            cells[0, 7] = x0y7; cells[1, 7] = x1y7;
            cells[2, 7] = x2y7; cells[3, 7] = x3y7;
            cells[4, 7] = x4y7; cells[5, 7] = x5y7;
            cells[6, 7] = x6y7; cells[7, 7] = x7y7;
        }
    }
}
