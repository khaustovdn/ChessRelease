using System.Windows.Forms;

namespace ChessRelease.Application.Presenter
{
    public interface IPresenter
    {
        Button prevButton;
        Button[,] buttons { get; set; } = new Button[8, 8];
        int[,] map;
    }
}