using System.Windows.Forms;

namespace ChessRelease.Application.Presenter
{
    public class Presenter : IPresenter
    {
        public Button prevButton;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public int[,] map;
    }
}