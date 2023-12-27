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
        public Bitmap chessSprites { get; set; } = new Bitmap("chess.png");
        public Board()
        {
            map = new int[8, 8]
            {
                {15,14,13,12,11,13,14,15},
                {16,16,16,16,16,16,16,16},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {26,26,26,26,26,26,26,26},
                {25,24,23,22,21,23,24,25},
            };
        }
        public Button CreateButton(int i, int j)
        {
            Button butt = new Button();
            butt.Size = new Size(50, 50);
            butt.Location = new Point(i * 50, j * 50);
            butt.Click += new EventHandler(OnPressFigure);
            butt = SkinButton(ColorChangedButton(butt, j, i), j, i);
            buttons[j, i] = butt;
            return butt;

    }
}