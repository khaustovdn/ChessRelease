using System.Drawing;
using System.Windows.Forms;

namespace ChessRelease.Application.Models
{
    public class Steps
    {
        public static Button StepColor(Button butt)
        {
            butt.BackColor = Color.Yellow;
            butt.Enabled = true;
            return butt;
        }
        public static Button[,] StepsWall(int IcurrFigure, int JcurrFigure, int currFigure, int[,] map, Button[,] buttons)
        {
            for (int g = JcurrFigure + 1; Check.InsideBorder(IcurrFigure, g); g++)//право по прямой
            {
                if (map[IcurrFigure, g] % 10 == 1)
                {
                    break;
                }
                if (map[IcurrFigure, g] / 10 == 0)
                {
                    buttons[IcurrFigure, g] = StepColor(buttons[IcurrFigure, g]);
                    continue;
                }
                else
                {
                    
                    if (map[IcurrFigure, g] / 10 != currFigure / 10)
                    {
                        buttons[IcurrFigure, g] = StepColor(buttons[IcurrFigure, g]);
                        break;
                    }
                    else
                    {
                        if (map[IcurrFigure, g] / 10 == currFigure / 10)
                        {
                            break;
                        }
                    }
                }
            }
            for (int g = JcurrFigure - 1; Check.InsideBorder(IcurrFigure, g); g--)//влево по прямой
            {
                if (map[IcurrFigure, g] % 10 == 1)
                {
                    break;
                }
                if (map[IcurrFigure, g] / 10 == 0)
                {
                    buttons[IcurrFigure, g] = StepColor(buttons[IcurrFigure, g]);
                    continue;
                }
                else
                {
                    if (map[IcurrFigure, g] / 10 != currFigure / 10)
                    {
                        if (map[IcurrFigure, g] % 10 == 1)
                        {
                            break;
                        }
                        buttons[IcurrFigure, g] = StepColor(buttons[IcurrFigure, g]);
                        break;
                    }
                    else
                    {
                        if (map[IcurrFigure, g] / 10 == currFigure / 10)
                        {
                            break;
                        }
                    }
                }
            }
            for (int g = IcurrFigure - 1; Check.InsideBorder(g, JcurrFigure); g--)//вниз по прямой
            {
                if (map[g, JcurrFigure] % 10 == 1)
                {
                    break;
                }
                if (map[g, JcurrFigure] / 10 == 0)
                {
                    buttons[g, JcurrFigure] = StepColor(buttons[g, JcurrFigure]);
                    continue;
                }
                else
                {
                    if (map[g, JcurrFigure] / 10 != currFigure / 10)
                    {
                        if (map[g, JcurrFigure] % 10 == 1)
                        {
                            break;
                        }
                        buttons[g, JcurrFigure] = StepColor(buttons[g, JcurrFigure]);
                        break;
                    }
                    else
                    {
                        if (map[g, JcurrFigure] / 10 == currFigure / 10)
                        {
                            break;
                        }
                    }
                }
            }
            for (int g = IcurrFigure + 1; Check.InsideBorder(g, JcurrFigure); g++)//вверх по прямой
            {
                if (map[g, JcurrFigure] % 10 == 1)
                {
                    break;
                }
                if (map[g, JcurrFigure] / 10 == 0)
                {
                    buttons[g, JcurrFigure] = StepColor(buttons[g, JcurrFigure]);
                    continue;
                }
                else
                {
                    if (map[g, JcurrFigure] / 10 != currFigure / 10)
                    {
                        
                        buttons[g, JcurrFigure] = StepColor(buttons[g, JcurrFigure]);
                        break;
                    }
                    else
                    {
                        if (map[g, JcurrFigure] / 10 == currFigure / 10)
                        {
                            break;
                        }
                    }
                }
            }
            return buttons;

        }
        public static int[] StepsWall(int IcurrFigure, int JcurrFigure, int[,] map)
        {
            int[] tmp = { -1, -1 };
            int player = map[IcurrFigure, JcurrFigure]/10;
            for (int g = JcurrFigure + 1; Check.InsideBorder(IcurrFigure, g); g++)//право по прямой
            {
                if (map[IcurrFigure, g] % 10 == 1 && player != map[IcurrFigure, g] / 10)
                {
                    tmp[0] = IcurrFigure;
                    tmp[1] = g;
                    return tmp;
                }
                if (map[IcurrFigure, g] % 10 != 0)
                {
                    break;
                }

            }
            for (int g = JcurrFigure - 1; Check.InsideBorder(IcurrFigure, g); g--)//влево по прямой
            {
                if (map[IcurrFigure, g] % 10 == 1 && player != map[IcurrFigure, g] / 10)
                {
                    tmp[0] = IcurrFigure;
                    tmp[1] = g;
                    return tmp;
                }
                if (map[IcurrFigure, g] % 10 != 0)
                {
                    break;
                }

            }
            for (int g = IcurrFigure - 1; Check.InsideBorder(g, JcurrFigure); g--)//вверх по прямой
            {
                if (map[g, JcurrFigure] % 10 == 1 && player != map[g, JcurrFigure] / 10)
                {
                    tmp[0] = g;
                    tmp[1] = JcurrFigure;
                    return tmp;
                }
                if (map[g, JcurrFigure] % 10 != 0)
                {
                    break;
                }

            }
            for (int g = IcurrFigure + 1; Check.InsideBorder(g, JcurrFigure); g++)//вниз по прямой
            {
                if (map[g, JcurrFigure] % 10 == 1 && player != map[g, JcurrFigure] / 10 )
                {
                    tmp[0] = g;
                    tmp[1] = JcurrFigure;
                    return tmp;
                }
                if (map[g, JcurrFigure] % 10 != 0)
                {
                    break;
                }
                
            }
            return tmp;

        }
    }
}