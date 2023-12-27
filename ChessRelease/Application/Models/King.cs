using System.Windows.Forms;

namespace ChessRelease.Application.Models
{
    public class King : IFigure
    {
        public int number { get; set; } = 6;
        public Button[,] buttons { get; set; } = new Button[8, 8];
        public King(Button[,] butt)
        {
            buttons = butt;
        }
        public static int[] KingFor(int[,] map, int player)
        {
            int[] tmp = [0, 0];
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if (map[i, j] / 10 == player && map[i,j] % 10 == 1)
                    {
                        tmp[0] = i;
                        tmp[1] = j;
                        return tmp;
                    }
                }
            }
            return tmp;
        }
        public Button[,] Move(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map)
        {
            int dir = currFigure / 10 == 1 ? 1 : -1;
            if (Check.InsideBorder(IcurrFigure, JcurrFigure + 1) && map[IcurrFigure, JcurrFigure + 1] / 10 != currFigure / 10)//вправо
            {
                buttons[IcurrFigure, JcurrFigure + 1].BackColor = Color.Yellow;
                buttons[IcurrFigure, JcurrFigure + 1].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure, JcurrFigure - 1) && map[IcurrFigure, JcurrFigure - 1] / 10 != currFigure / 10)//влево
            {
                buttons[IcurrFigure, JcurrFigure - 1].BackColor = Color.Yellow;
                buttons[IcurrFigure, JcurrFigure - 1].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure + 1, JcurrFigure) && map[IcurrFigure + 1, JcurrFigure] / 10 != currFigure / 10)//вниз
            {
                buttons[IcurrFigure + 1, JcurrFigure].BackColor = Color.Yellow;
                buttons[IcurrFigure + 1, JcurrFigure].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure - 1, JcurrFigure) && map[IcurrFigure - 1, JcurrFigure] / 10 != currFigure / 10)//вверх
            {
                buttons[IcurrFigure - 1  ,JcurrFigure].BackColor = Color.Yellow;
                buttons[IcurrFigure - 1 , JcurrFigure].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure - 1, JcurrFigure + 1) && map[IcurrFigure - 1, JcurrFigure + 1] / 10 != currFigure / 10)//по диагонали вверх
            {
                buttons[IcurrFigure - 1, JcurrFigure + 1].BackColor = Color.Yellow;
                buttons[IcurrFigure - 1, JcurrFigure + 1].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure - 1, JcurrFigure - 1) && map[IcurrFigure - 1, JcurrFigure - 1] / 10 != currFigure / 10)//по диагонали вверх
            {
                buttons[IcurrFigure - 1, JcurrFigure - 1].BackColor = Color.Yellow;
                buttons[IcurrFigure - 1, JcurrFigure - 1].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure - 1, JcurrFigure) && map[IcurrFigure - 1, JcurrFigure] / 10 != currFigure / 10)//по диагонали вверх
            {
                buttons[IcurrFigure - 1, JcurrFigure ].BackColor = Color.Yellow;
                buttons[IcurrFigure - 1, JcurrFigure ].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure + 1, JcurrFigure + 1) && map[IcurrFigure + 1, JcurrFigure + 1] / 10 != currFigure / 10)//по диагонали вниз
            {
                buttons[IcurrFigure + 1, JcurrFigure + 1].BackColor = Color.Yellow;
                buttons[IcurrFigure + 1, JcurrFigure + 1].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure + 1, JcurrFigure - 1) && map[IcurrFigure + 1, JcurrFigure - 1]/ 10 != currFigure/10 )//по диагонали вниз
            {
                buttons[IcurrFigure + 1, JcurrFigure - 1].BackColor = Color.Yellow;
                buttons[IcurrFigure + 1, JcurrFigure - 1].Enabled = true;
            }
            if (Check.InsideBorder(IcurrFigure + 1, JcurrFigure) && map[IcurrFigure + 1, JcurrFigure] / 10 != currFigure / 10)//по диагонали вниз
            {
                buttons[IcurrFigure + 1, JcurrFigure].BackColor = Color.Yellow;
                buttons[IcurrFigure + 1, JcurrFigure].Enabled = true;
            }

            return buttons;
        }
    }
}