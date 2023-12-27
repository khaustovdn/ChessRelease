using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public class Horse : IFigure
{
    public Horse(Button[,] butt)
    {
        Buttons = butt;
    }

    public int Number { get; set; } = 6;
    public Button[,] Buttons { get; set; }

    public Button[,] Move(int icurrFigure, int jcurrFigure, int currFigure, int[,] map)
    {
        Buttons = Steps.StepHorse(icurrFigure, jcurrFigure, currFigure, map, Buttons);
        return Buttons;
    }

    public bool Check(int icurrFigure, int jcurrFigure, int currFigure, int[,] map)
    {
        return Steps.StepHorse(icurrFigure, jcurrFigure, currFigure, map);
    }
}