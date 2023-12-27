using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public interface IFigure
{
    Button[,] Buttons { get; set; }
    int Number { get; set; }
    Button[,] Move(int icurrFigure, int jcurrFigure, int currFigure, int[,] map);
}