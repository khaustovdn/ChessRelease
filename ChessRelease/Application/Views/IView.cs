using ChessRelease.Application.Presenter;

namespace ChessRelease.Application.Views
{
    public interface IView
    {
        public interface IView
        {
            void Show();
            IPresenter _presenter { get; set; }
            public void Render();
        }
    }
}