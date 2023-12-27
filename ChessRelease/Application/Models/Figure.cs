namespace ChessRelease.Application.Models
{
    public class Figure : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public Figure(Button[,] butt )
        {
            buttons = butt;
        }
        public Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
        {
            
            buttons = Steps.StepFigure(IcurrFigure, JcurrFigure, currFigure, map, buttons);  
            return buttons;
        }
        public bool Check(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
        {
            return Steps.StepFigure(IcurrFigure, JcurrFigure, currFigure, map);
        }
    }
}