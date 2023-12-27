using ChessRelease.Application.Presenter;

namespace ChessRelease.Application.Views;

public interface IView
{
    IPresenter Presenter { get; set; }
    void Show();
    public void Render();
}