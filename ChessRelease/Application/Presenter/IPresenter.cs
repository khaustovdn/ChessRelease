using System.Windows.Forms;

namespace ChessRelease.Application.Presenter
{
    public interface IPresenter
    {
        Button prevButton { get; set; }
        Button[,] buttons { get; set; }
        int[,] map { get; set; }
    }
}