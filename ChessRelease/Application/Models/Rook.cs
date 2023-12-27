namespace ChessRelease.Application.Models
{
    public class Rook : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public Rook(Button[,] butt)
        {
            buttons = butt;
        }
    }
}