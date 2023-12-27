using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public class Elephant : IFigure
{
    public Elephant(Button[,] butt)
    {
        Buttons = butt;
    }

    public int Number { get; set; } = 6;
    public Button[,] Buttons { get; set; }

    public Button[,] Move(int icurrFigure, int jcurrFigure, int currFigure, int[,] map)
    {
        Buttons = Steps.StepsDiagonal(icurrFigure, jcurrFigure, currFigure, map, Buttons);
        return Buttons;
    }

    public bool Check(int icurrFigure, int jcurrFigure, int[,] map)
    {
        int[] tmp = { -1, -1 };

        tmp = Steps.StepsDiagonal(icurrFigure, jcurrFigure, map);
        if (tmp[0] == -1) return false;
        return true;
    }
}