namespace ChessRelease.Application.Models
{
    public class Rook : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public Rook(Button[,] butt)
        {
            buttons = butt;
        }
        public Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
        {

            buttons = Steps.StepsWall(IcurrFigure, JcurrFigure, currFigure, map, buttons);
            return buttons;
        }
        public  bool Check(int IcurrFigure, int JcurrFigure,int[,] map)
        {
            int[] tmp = {-1,-1};
            tmp = Steps.StepsWall(IcurrFigure, JcurrFigure, map);
            if (tmp[0] == -1 || tmp[1] == -1)
            {
                return false;
            }
            return true;

    }
}