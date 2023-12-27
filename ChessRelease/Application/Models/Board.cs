using System.Drawing;
using System.Windows.Forms;

namespace ChessRelease.Application.Models
{
    public class Board
    {
        public int[,] map { get; set; }
        public bool check = false;

        public Button[,] buttons { get; set; } = new Button[8, 8];
        public int player { get; set; } = 1;
        public Button prevButton { get; set; }
        public Color prevColor { get; set; }

        public bool isMoving { get; set; } = false;
        public Bitmap chessSprites { get; set; } = new Bitmap("C:\\Users\\satal\\OneDrive\\Рабочий стол\\chesspng\\chess.png");
    }
}