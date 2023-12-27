using System.Windows.Forms;

namespace ChessRelease.Application.Presenter
{
    public class Presenter : IPresenter
    {
        public Button prevButton { get; set;  }
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public int[,] map { get; set; }
        
        public Presenter() 
        {
            map = new int[8, 8]
            {
                {15,14,13,12,11,13,14,15},
                {16,16,16,16,16,16,16,16},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {26,26,26,26,26,26,26,26},
                {25,24,23,22,21,23,24,25},
            };
        }
    }
}