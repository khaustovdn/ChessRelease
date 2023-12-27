using System.Drawing;
using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public class King : IFigure
{
    public King(Button[,] butt)
    {
        Buttons = butt;
    }

    public int Number { get; set; } = 6;
    public Button[,] Buttons { get; set; }

    public Button[,] Move(int icurrFigure, int jcurrFigure, int currFigure, int[,] map)
    {
        var dir = currFigure / 10 == 1 ? 1 : -1;
        if (Check.InsideBorder(icurrFigure, jcurrFigure + 1) &&
            map[icurrFigure, jcurrFigure + 1] / 10 != currFigure / 10) //вправо
        {
            Buttons[icurrFigure, jcurrFigure + 1].BackColor = Color.Yellow;
            Buttons[icurrFigure, jcurrFigure + 1].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure, jcurrFigure - 1) &&
            map[icurrFigure, jcurrFigure - 1] / 10 != currFigure / 10) //влево
        {
            Buttons[icurrFigure, jcurrFigure - 1].BackColor = Color.Yellow;
            Buttons[icurrFigure, jcurrFigure - 1].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure + 1, jcurrFigure) &&
            map[icurrFigure + 1, jcurrFigure] / 10 != currFigure / 10) //вниз
        {
            Buttons[icurrFigure + 1, jcurrFigure].BackColor = Color.Yellow;
            Buttons[icurrFigure + 1, jcurrFigure].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure - 1, jcurrFigure) &&
            map[icurrFigure - 1, jcurrFigure] / 10 != currFigure / 10) //вверх
        {
            Buttons[icurrFigure - 1, jcurrFigure].BackColor = Color.Yellow;
            Buttons[icurrFigure - 1, jcurrFigure].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure - 1, jcurrFigure + 1) &&
            map[icurrFigure - 1, jcurrFigure + 1] / 10 != currFigure / 10) //по диагонали вверх
        {
            Buttons[icurrFigure - 1, jcurrFigure + 1].BackColor = Color.Yellow;
            Buttons[icurrFigure - 1, jcurrFigure + 1].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure - 1, jcurrFigure - 1) &&
            map[icurrFigure - 1, jcurrFigure - 1] / 10 != currFigure / 10) //по диагонали вверх
        {
            Buttons[icurrFigure - 1, jcurrFigure - 1].BackColor = Color.Yellow;
            Buttons[icurrFigure - 1, jcurrFigure - 1].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure - 1, jcurrFigure) &&
            map[icurrFigure - 1, jcurrFigure] / 10 != currFigure / 10) //по диагонали вверх
        {
            Buttons[icurrFigure - 1, jcurrFigure].BackColor = Color.Yellow;
            Buttons[icurrFigure - 1, jcurrFigure].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure + 1, jcurrFigure + 1) &&
            map[icurrFigure + 1, jcurrFigure + 1] / 10 != currFigure / 10) //по диагонали вниз
        {
            Buttons[icurrFigure + 1, jcurrFigure + 1].BackColor = Color.Yellow;
            Buttons[icurrFigure + 1, jcurrFigure + 1].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure + 1, jcurrFigure - 1) &&
            map[icurrFigure + 1, jcurrFigure - 1] / 10 != currFigure / 10) //по диагонали вниз
        {
            Buttons[icurrFigure + 1, jcurrFigure - 1].BackColor = Color.Yellow;
            Buttons[icurrFigure + 1, jcurrFigure - 1].Enabled = true;
        }

        if (Check.InsideBorder(icurrFigure + 1, jcurrFigure) &&
            map[icurrFigure + 1, jcurrFigure] / 10 != currFigure / 10) //по диагонали вниз
        {
            Buttons[icurrFigure + 1, jcurrFigure].BackColor = Color.Yellow;
            Buttons[icurrFigure + 1, jcurrFigure].Enabled = true;
        }

        return Buttons;
    }

    public static int[] KingFor(int[,] map, int player)
    {
        int[] tmp = [0, 0];
        for (var i = 0; i < 8; i++)
        for (var j = 0; j < 8; j++)
            if (map[i, j] / 10 == player && map[i, j] % 10 == 1)
            {
                tmp[0] = i;
                tmp[1] = j;
                return tmp;
            }

        return tmp;
    }
}