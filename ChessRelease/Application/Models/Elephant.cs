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
    }
}