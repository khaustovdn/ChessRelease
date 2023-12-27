namespace ChessRelease.Application.Models
{
    public class Horse : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public Horse(Button[,] butt)
        {
            buttons = butt;
        }
    }
}