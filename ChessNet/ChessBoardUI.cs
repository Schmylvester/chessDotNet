using System.Windows.Forms;
using ChessBackend;

//TODO: Highlight selected unit
//TODO: Highlight valid moves

namespace ChessNet
{
    public partial class ChessBoard : Form
    {
        Board board = null;
        Button[,,] cells = null;
        Piece selected_piece = null;
        Team active_team = Team.White;

        public ChessBoard()
        {
            InitializeComponent();
            linkButtons();
            //get the pieces from the board
            board = new Board();
            updateBoard();
        }

        /// <summary>
        /// displays the pieces and their
        /// locations on the board
        /// </summary>
        void updateBoard()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Piece unit = board.getCell(x, y).unit;
                    if (unit == null)
                    {
                        cells[0, x, y].Text = "";
                        cells[1, x, y].Text = "";
                    }
                    else
                    {
                        int b = unit.board_a ? 0 : 1;
                        cells[b, x, y].Text = unit.id;
                        cells[1 - b, x, y].Text = "";
                    }
                }
            }
        }

        void linkButtons()
        {
            //TODO: there is definitely a better way to do this, find it
            cells = new Button[2, 8, 8];
            cells[0, 0, 0] = x0y0; cells[0, 1, 0] = x1y0; cells[0, 2, 0] = x2y0; cells[0, 3, 0] = x3y0;
            cells[0, 4, 0] = x4y0; cells[0, 5, 0] = x5y0; cells[0, 6, 0] = x6y0; cells[0, 7, 0] = x7y0;

            cells[0, 0, 1] = x0y1; cells[0, 1, 1] = x1y1; cells[0, 2, 1] = x2y1; cells[0, 3, 1] = x3y1;
            cells[0, 4, 1] = x4y1; cells[0, 5, 1] = x5y1; cells[0, 6, 1] = x6y1; cells[0, 7, 1] = x7y1;

            cells[0, 0, 2] = x0y2; cells[0, 1, 2] = x1y2; cells[0, 2, 2] = x2y2; cells[0, 3, 2] = x3y2;
            cells[0, 4, 2] = x4y2; cells[0, 5, 2] = x5y2; cells[0, 6, 2] = x6y2; cells[0, 7, 2] = x7y2;

            cells[0, 0, 3] = x0y3; cells[0, 1, 3] = x1y3; cells[0, 2, 3] = x2y3; cells[0, 3, 3] = x3y3;
            cells[0, 4, 3] = x4y3; cells[0, 5, 3] = x5y3; cells[0, 6, 3] = x6y3; cells[0, 7, 3] = x7y3;

            cells[0, 0, 4] = x0y4; cells[0, 1, 4] = x1y4; cells[0, 2, 4] = x2y4; cells[0, 3, 4] = x3y4;
            cells[0, 4, 4] = x4y4; cells[0, 5, 4] = x5y4; cells[0, 6, 4] = x6y4; cells[0, 7, 4] = x7y4;

            cells[0, 0, 5] = x0y5; cells[0, 1, 5] = x1y5; cells[0, 2, 5] = x2y5; cells[0, 3, 5] = x3y5;
            cells[0, 4, 5] = x4y5; cells[0, 5, 5] = x5y5; cells[0, 6, 5] = x6y5; cells[0, 7, 5] = x7y5;

            cells[0, 0, 6] = x0y6; cells[0, 1, 6] = x1y6; cells[0, 2, 6] = x2y6; cells[0, 3, 6] = x3y6;
            cells[0, 4, 6] = x4y6; cells[0, 5, 6] = x5y6; cells[0, 6, 6] = x6y6; cells[0, 7, 6] = x7y6;

            cells[0, 0, 7] = x0y7; cells[0, 1, 7] = x1y7; cells[0, 2, 7] = x2y7; cells[0, 3, 7] = x3y7;
            cells[0, 4, 7] = x4y7; cells[0, 5, 7] = x5y7; cells[0, 6, 7] = x6y7; cells[0, 7, 7] = x7y7;

            cells[1, 0, 0] = x0y0B; cells[1, 1, 0] = x1y0B; cells[1, 2, 0] = x2y0B; cells[1, 3, 0] = x3y0B;
            cells[1, 4, 0] = x4y0B; cells[1, 5, 0] = x5y0B; cells[1, 6, 0] = x6y0B; cells[1, 7, 0] = x7y0B;

            cells[1, 0, 1] = x0y1B; cells[1, 1, 1] = x1y1B; cells[1, 2, 1] = x2y1B; cells[1, 3, 1] = x3y1B;
            cells[1, 4, 1] = x4y1B; cells[1, 5, 1] = x5y1B; cells[1, 6, 1] = x6y1B; cells[1, 7, 1] = x7y1B;

            cells[1, 0, 2] = x0y2B; cells[1, 1, 2] = x1y2B; cells[1, 2, 2] = x2y2B; cells[1, 3, 2] = x3y2B;
            cells[1, 4, 2] = x4y2B; cells[1, 5, 2] = x5y2B; cells[1, 6, 2] = x6y2B; cells[1, 7, 2] = x7y2B;

            cells[1, 0, 3] = x0y3B; cells[1, 1, 3] = x1y3B; cells[1, 2, 3] = x2y3B; cells[1, 3, 3] = x3y3B;
            cells[1, 4, 3] = x4y3B; cells[1, 5, 3] = x5y3B; cells[1, 6, 3] = x6y3B; cells[1, 7, 3] = x7y3B;

            cells[1, 0, 4] = x0y4B; cells[1, 1, 4] = x1y4B; cells[1, 2, 4] = x2y4B; cells[1, 3, 4] = x3y4B;
            cells[1, 4, 4] = x4y4B; cells[1, 5, 4] = x5y4B; cells[1, 6, 4] = x6y4B; cells[1, 7, 4] = x7y4B;

            cells[1, 0, 5] = x0y5B; cells[1, 1, 5] = x1y5B; cells[1, 2, 5] = x2y5B; cells[1, 3, 5] = x3y5B;
            cells[1, 4, 5] = x4y5B; cells[1, 5, 5] = x5y5B; cells[1, 6, 5] = x6y5B; cells[1, 7, 5] = x7y5B;

            cells[1, 0, 6] = x0y6B; cells[1, 1, 6] = x1y6B; cells[1, 2, 6] = x2y6B; cells[1, 3, 6] = x3y6B;
            cells[1, 4, 6] = x4y6B; cells[1, 5, 6] = x5y6B; cells[1, 6, 6] = x6y6B; cells[1, 7, 6] = x7y6B;

            cells[1, 0, 7] = x0y7B; cells[1, 1, 7] = x1y7B; cells[1, 2, 7] = x2y7B; cells[1, 3, 7] = x3y7B;
            cells[1, 4, 7] = x4y7B; cells[1, 5, 7] = x5y7B; cells[1, 6, 7] = x6y7B; cells[1, 7, 7] = x7y7B;
        }

        /// <summary>
        /// When a cell is clicked on, will identify the x and y
        /// values of the cell and handle the click
        /// </summary>
        /// <param name="sender">Object sending the clicks</param>
        /// <param name="e">Click arguments</param>
        private void handleClick(object sender, System.EventArgs e)
        {
            for (int b = 0; b < 2; b++)
            {
                for (int x = 0; x < 8; x++)
                {
                    for (int y = 0; y < 8; y++)
                    {
                        if (cells[b, x, y] == (sender))
                        {
                            if (selected_piece == null)
                            {
                                selectPiece(board.getCell(x, y));
                            }
                            else
                            {
                                movePiece(board.getCell(x, y));
                            }
                            return;
                        }
                    }
                }
            }
        }

        void selectPiece(Cell clicked_cell)
        {
            Piece in_cell = clicked_cell.unit;
            if (in_cell != null)
            {
                if (in_cell.unit_team == active_team)
                {
                    selected_piece = in_cell;
                }
                else
                {
                    Feedback.Text = "It is " + active_team.ToString().ToLower() + "'s turn";
                }
            }
            else
            {
                Feedback.Text = "Please select a unit";
            }
        }

        void movePiece(Cell clicked_cell)
        {
            string feedback = "";
            if (selected_piece.validMove(clicked_cell, ref feedback))
            {
                selected_piece.move(clicked_cell, ref feedback);
                updateBoard();
                //next player's turn
                active_team = 3 - active_team;
                board.checkFeedback(active_team, ref feedback);
            }
            Feedback.Text = feedback;
            selected_piece = null;
        }
    }
}
