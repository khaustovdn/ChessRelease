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
        
        private Button SkinButton(Button butt, int i, int j)
        {
            switch (map[i, j] / 10)
            {
                case 1:
                    Image part = new Bitmap(50, 50);
                    Graphics g = Graphics.FromImage(part);
                    g.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[i, j] % 10 - 1), 0, 150, 150, GraphicsUnit.Pixel);
                    butt.BackgroundImage = part;
                    break;

                case 2:
                    Image part1 = new Bitmap(50, 50);
                    Graphics g1 = Graphics.FromImage(part1);
                    g1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (map[i, j] % 10 - 1), 150, 150, 150, GraphicsUnit.Pixel);
                    butt.BackgroundImage = part1;
                    break;
            }
            return butt;
        }
        private void ChangePlayer()
        {
            switch (player)
            {
                case 1:
                    player = 2; break;
                case 2:
                    player = 1; break;
            }
        }
        private Button ColorChangedButton(Button butt, int i, int j)
        {
            if (i == 0 || i % 2 == 0)
            {
                if (j == 0 || j % 2 == 0)
                    butt.BackColor = Color.White;
                else
                    butt.BackColor = Color.Brown;
            }
            else
            {
                if (j == 0 || j % 2 == 0)
                    butt.BackColor = Color.Brown;
                else
                    butt.BackColor = Color.White;
            }
            return butt;
        }
        private void ColorChangedAllButton()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == 0 || i % 2 == 0)
                    {
                        if (j == 0 || j % 2 == 0)
                            buttons[i, j].BackColor = Color.White;
                        else
                            buttons[i, j].BackColor = Color.Brown;
                    }
                    else
                    {
                        if (j == 0 || j % 2 == 0)
                            buttons[i, j].BackColor = Color.Brown;
                        else
                            buttons[i, j].BackColor = Color.White;
                    }
                }
            }
        }
    }
}