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
    }
}