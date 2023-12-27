using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public class Queen
{
    public Queen(Button[,] butt)
    {
        buttons = butt;
    }

    public int number { get; set; } = 6;
    public Button[,] buttons { get; set; } = new Button[8, 8];

    public Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
    {
        buttons = Steps.StepsDiagonal(IcurrFigure, JcurrFigure, currFigure, map, buttons);
        buttons = Steps.StepsWall(IcurrFigure, JcurrFigure, currFigure, map, buttons);

        return buttons;
    }

    public bool Check(int icurrFigure, int jcurrFigure, int[,] map)
    {
        var tmpWall = Steps.StepsWall(icurrFigure, jcurrFigure, map);
        var tmpDiagonal = Steps.StepsDiagonal(icurrFigure, jcurrFigure, map);
        if (tmpWall[0] == -1)
        {
            if (tmpDiagonal[0] == -1)
                return false;
            return true;
        }

        return true;
    }
}