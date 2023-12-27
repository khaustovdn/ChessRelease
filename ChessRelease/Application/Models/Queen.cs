using System.Windows.Forms;

namespace ChessRelease.Application.Models
{
    public class Queen
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public Queen(Button[,] butt)
        {
            buttons = butt;
        }
        public Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
        {
            buttons = Steps.StepsDiagonal(IcurrFigure,JcurrFigure,currFigure,map,buttons);
            buttons = Steps.StepsWall(IcurrFigure, JcurrFigure, currFigure, map, buttons);

            return buttons;
        }
    }
}