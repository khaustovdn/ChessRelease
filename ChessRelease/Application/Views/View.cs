using System.Windows.Forms;
using ChessRelease.Application.Presenter;

namespace ChessRelease.Application.Views
{
    public class View : Form, IView
    {
        public IPresenter _presenter { get; set; }

        public View(IPresenter presenter)
        {
            _presenter = presenter;
            Render();
        }
        public  void Render()
        {

        }

        public void ShowWindow()
        {
            System.Windows.Forms.Application.Run(this);
        }
    }
}