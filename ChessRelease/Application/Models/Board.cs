using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public class Board
{
    private bool _check;

    private int[,] Map { get; set; } =
    {
        { 15, 14, 13, 12, 11, 13, 14, 15 },
        { 16, 16, 16, 16, 16, 16, 16, 16 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0 },
        { 26, 26, 26, 26, 26, 26, 26, 26 },
        { 25, 24, 23, 22, 21, 23, 24, 25 }
    };

    private Button[,] Buttons { get; set; } = new Button[8, 8];
    private int Player { get; set; } = 1;
    private Button PrevButton { get; set; }
    private bool IsMoving { get; set; }
    private Bitmap ChessSprites { get; set; } = new("chess.png");

    public Button CreateButton(int i, int j)
    {
        var butt = new Button();
        butt.Size = new Size(50, 50);
        butt.Location = new Point(i * 50, j * 50);
        butt.Click += OnPressFigure;
        butt = SkinButton(ColorChangedButton(butt, j, i), j, i);
        Buttons[j, i] = butt;
        return butt;
    }

    private Button SkinButton(Button butt, int i, int j)
    {
        switch (Map[i, j] / 10)
        {
            case 1:
                Image part = new Bitmap(50, 50);
                var g = Graphics.FromImage(part);
                g.DrawImage(ChessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (Map[i, j] % 10 - 1), 0, 150, 150,
                    GraphicsUnit.Pixel);
                butt.BackgroundImage = part;
                break;

            case 2:
                Image part1 = new Bitmap(50, 50);
                var g1 = Graphics.FromImage(part1);
                g1.DrawImage(ChessSprites, new Rectangle(0, 0, 50, 50), 0 + 150 * (Map[i, j] % 10 - 1), 150, 150, 150,
                    GraphicsUnit.Pixel);
                butt.BackgroundImage = part1;
                break;
        }

        return butt;
    }

    private void ChangePlayer()
    {
        switch (Player)
        {
            case 1:
                Player = 2;
                break;
            case 2:
                Player = 1;
                break;
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
        for (var i = 0; i < 8; i++)
        for (var j = 0; j < 8; j++)
            if (i == 0 || i % 2 == 0)
            {
                if (j == 0 || j % 2 == 0)
                    Buttons[i, j].BackColor = Color.White;
                else
                    Buttons[i, j].BackColor = Color.Brown;
            }
            else
            {
                if (j == 0 || j % 2 == 0)
                    Buttons[i, j].BackColor = Color.Brown;
                else
                    Buttons[i, j].BackColor = Color.White;
            }
    }

    private int[] FindKing()
    {
        var tmp = King.KingFor(Map, Player);
        return tmp;
    }

    private void OnPressFigure(object sender, EventArgs e)
    {
        var pressedButton = sender as Button; // чисто для удобства
        if (pressedButton != null)
        {
            if (_check)
            {
                pressedButton.BackColor = Color.Red;
                DeactiveButtons();
                ShowSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50,
                    Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);
                _check = false;
                IsMoving = true;
                pressedButton.Enabled = false;
            }
            else
            {
                if (Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0 &&
                    Player == Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] / 10)
                {
                    pressedButton.BackColor = Color.Red;
                    DeactiveButtons();
                    ShowSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50,
                        Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);
                    if (IsMoving)
                    {
                        IsMoving = false;
                        ColorChangedAllButton();
                        ActivateButtons();
                    }
                    else
                    {
                        IsMoving = true;
                    }
                }
                else
                {
                    if (IsMoving)
                    {
                        // Меняем местами кнопки

                        if (Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] is not 0)
                            Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = 0;
                        (Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50], Map[PrevButton.Location.Y / 50, PrevButton.Location.X / 50]) = (Map[PrevButton.Location.Y / 50, PrevButton.Location.X / 50], Map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);
                        pressedButton.BackgroundImage = PrevButton.BackgroundImage;
                        PrevButton.BackgroundImage = null;
                        IsMoving = false;
                        // Меняем местами кнопки\
                        if (CheckSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50, Map))
                        {
                            ChangePlayer();
                            ColorChangedAllButton();
                            DeactiveButtons();
                            _check = true;
                            var tmp = FindKing();
                            Buttons[tmp[0], tmp[1]].BackColor = Color.Red;
                            Buttons[tmp[0], tmp[1]].Enabled = true;
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

            PrevButton = pressedButton;
        }
    }

    private void DeactiveButtons()
    {
        for (var i = 0; i < 8; i++)
        for (var j = 0; j < 8; j++)
            Buttons[i, j].Enabled = false;
    }

    private void ActivateButtons()
    {
        for (var i = 0; i < 8; i++)
        for (var j = 0; j < 8; j++)
            Buttons[i, j].Enabled = true;
    }

    private void ShowSteps(int icurrFigure, int jcurrFigure, int currFigure)
    {
        switch (currFigure % 10)
        {
            case 6:
                var figure = new Figure(Buttons);
                Buttons = figure.Move(icurrFigure, jcurrFigure, currFigure, Map);
                Buttons[icurrFigure, jcurrFigure].Enabled = true;
                break;
            case 5:
                var rook = new Rook(Buttons);
                Buttons = rook.Move(icurrFigure, jcurrFigure, currFigure, Map);
                Buttons[icurrFigure, jcurrFigure].Enabled = true;
                break;
            case 4:
                var horse = new Horse(Buttons);
                Buttons = horse.Move(icurrFigure, jcurrFigure, currFigure, Map);
                Buttons[icurrFigure, jcurrFigure].Enabled = true;
                break;
            case 3:
                var elephant = new Elephant(Buttons);
                Buttons = elephant.Move(icurrFigure, jcurrFigure, currFigure, Map);
                Buttons[icurrFigure, jcurrFigure].Enabled = true;
                break;
            case 2:
                var queen = new Queen(Buttons);
                Buttons = queen.Move(icurrFigure, jcurrFigure, currFigure, Map);
                Buttons[icurrFigure, jcurrFigure].Enabled = true;
                break;
            case 1:
                var king = new King(Buttons);
                Buttons = king.Move(icurrFigure, jcurrFigure, currFigure, Map);
                Buttons[icurrFigure, jcurrFigure].Enabled = true;
                break;
        }
    }

    private bool CheckSteps(int icurrFigure, int jcurrFigure, int[,] map)
    {
        var currFigure = map[icurrFigure, jcurrFigure] % 10;
        switch (currFigure)
        {
            case 5:
                var rook = new Rook(Buttons);
                return rook.Check(icurrFigure, jcurrFigure, map);
            case 6:
                var figure = new Figure(Buttons);
                return figure.Check(icurrFigure, jcurrFigure, map[icurrFigure, jcurrFigure], map);
            case 4:
                var horse = new Horse(Buttons);
                return horse.Check(icurrFigure, jcurrFigure, map[icurrFigure, jcurrFigure], map);
            case 3:
                var elephant = new Elephant(Buttons);
                return elephant.Check(icurrFigure, jcurrFigure, map);
            case 2:
                var queen = new Queen(Buttons);
                return queen.Check(icurrFigure, jcurrFigure, map);
        }

        return false;
    }
}