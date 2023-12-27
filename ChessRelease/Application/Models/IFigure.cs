using System.Windows.Forms;

namespace ChessRelease.Application.Models
{
    public interface IFigure
    {
        Button[,] buttons { get; set; }
        int number {  get; set; }
        Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map);
    }
}