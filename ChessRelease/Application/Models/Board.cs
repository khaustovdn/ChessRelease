using System;
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
        
        private int[] FindKing()
        {
            int[] tmp = King.KingFor(map, player);
            return tmp;
        }
        private void OnPressFigure(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button; // чисто для удобства
            prevColor = pressedButton.BackColor;

            if (check == true)
            {
                pressedButton.BackColor = Color.Red;
                DeactiveButtons();
                ShowSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50, map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);
                check = false;
                isMoving = true;
                pressedButton.Enabled = false;
            }
            else
            {
                if (map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0 && player == map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] / 10)
                {

                    pressedButton.BackColor = Color.Red;
                    DeactiveButtons();
                    ShowSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50, map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);
                    if (isMoving)
                    {
                        isMoving = false;
                        ColorChangedAllButton();
                        ActivateButtons();
                    }
                    else isMoving = true;

                }
                else
                {
                    if (isMoving == true)
                    {

                        // Меняем местами кнопки

                        if (map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0)
                        {
                            map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = 0;
                        }
                        int temp = map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50];
                        map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = map[prevButton.Location.Y / 50, prevButton.Location.X / 50];
                        map[prevButton.Location.Y / 50, prevButton.Location.X / 50] = temp;
                        pressedButton.BackgroundImage = prevButton.BackgroundImage;
                        prevButton.BackgroundImage = null;
                        isMoving = false;
                        // Меняем местами кнопки\
                        if (CheckSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50, map))
                        {
                            ChangePlayer();
                            ColorChangedAllButton();
                            DeactiveButtons();
                            check = true;
                            int[] tmp = FindKing();
                            buttons[tmp[0], tmp[1]].BackColor = Color.Red;
                            buttons[tmp[0], tmp[1]].Enabled = true;
                        }
                        else
                        {
                            ChangePlayer();
                            ColorChangedAllButton();
                            ActivateButtons();
                        }
                    }
                }
            }
            prevButton = pressedButton;
        }
        private void DeactiveButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }
        private void ActivateButtons()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    buttons[i, j].Enabled = true;
                }
            }
        }
        private void ShowSteps(int IcurrFigure, int JcurrFigure, int currFigure)
        {
            switch (currFigure % 10)
            {
                case 6:
                    Figure figure = new Figure(buttons);
                    buttons = figure.Move(IcurrFigure, JcurrFigure, currFigure, map);
                    buttons[IcurrFigure, JcurrFigure].Enabled = true;
                    break;
                case 5:
                    Rook rook = new Rook(buttons);
                    buttons = rook.Move(IcurrFigure, JcurrFigure, currFigure, map);
                    buttons[IcurrFigure, JcurrFigure].Enabled = true;
                    break;
                case 4:
                    Horse horse = new Horse(buttons);
                    buttons = horse.Move(IcurrFigure, JcurrFigure, currFigure, map);
                    buttons[IcurrFigure, JcurrFigure].Enabled = true;
                    break;
                case 3:
                    Elephant elephant = new Elephant(buttons);
                    buttons = elephant.Move(IcurrFigure, JcurrFigure, currFigure, map);
                    buttons[IcurrFigure, JcurrFigure].Enabled = true;
                    break;
                case 2:
                    Queen queen = new Queen(buttons);
                    buttons = queen.Move(IcurrFigure, JcurrFigure, currFigure, map);
                    buttons[IcurrFigure, JcurrFigure].Enabled = true;
                    break;
                case 1:
                    King king = new King(buttons);
                    buttons = king.Move(IcurrFigure, JcurrFigure, currFigure, map);
                    buttons[IcurrFigure, JcurrFigure].Enabled = true;
                    break;

            }
        }
        private bool CheckSteps(int IcurrFigure, int JcurrFigure, int[,] map)
        {
            int currFigure = map[IcurrFigure, JcurrFigure] % 10;
            switch (currFigure)
            {
                case 5:
                    Rook rook = new Rook(buttons);
                    return rook.Check(IcurrFigure,JcurrFigure,map);
                case 6:
                    Figure figure = new Figure(buttons);
                    return figure.Check(IcurrFigure, JcurrFigure, map[IcurrFigure, JcurrFigure], map);
                case 4:
                    Horse horse = new Horse(buttons);
                    return horse.Check(IcurrFigure, JcurrFigure,map[IcurrFigure, JcurrFigure],map);
                case 3:
                    Elephant elephant = new Elephant(buttons);
                    return elephant.Check(IcurrFigure, JcurrFigure, map);
                case 2:
                    Queen queen = new Queen(buttons);
                    return queen.Check(IcurrFigure, JcurrFigure, map);

            }
            return false;
        }

    }
}