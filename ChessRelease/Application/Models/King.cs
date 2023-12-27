namespace ChessRelease.Application.Models
{
    public class King : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public King(Button[,] butt)
        {
            buttons = butt;
        }
    }
}