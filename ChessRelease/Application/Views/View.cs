using System.Windows.Forms;
using ChessRelease.Application.Presenter;

namespace ChessRelease.Application.Views;

public class View : Form, IView
{
    public View(IPresenter presenter)
    {
        Presenter = presenter;
        Render();
    }

    public IPresenter Presenter { get; set; }

    public void Render()
    {
    }
}