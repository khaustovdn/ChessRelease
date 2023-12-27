using System.Windows.Forms;

namespace ChessRelease.Application.Models
{
    public class Elephant : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public Elephant(Button[,] butt)
        {
            buttons = butt;
        }
        
        public Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
        {
            buttons = Steps.StepsDiagonal(IcurrFigure, JcurrFigure, currFigure, map, buttons);
            return buttons;
        }
        public bool Check(int IcurrFigure, int JcurrFigure, int[,] map)
        {
            int[] tmp = { -1, -1 };
           
            tmp = Steps.StepsDiagonal(IcurrFigure, JcurrFigure, map);
            if (tmp[0] == -1)
            {
                return false;
            }
            return true;
        }
    }
}