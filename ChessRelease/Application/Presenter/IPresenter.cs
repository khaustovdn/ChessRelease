using System.Windows.Forms;

namespace ChessRelease.Application.Presenter;

public interface IPresenter
{
    Button PrevButton { get; set; }
    Button[,] Buttons { get; set; }
    int[,] Map { get; set; }
}