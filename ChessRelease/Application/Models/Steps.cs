using System.Drawing;
using System.Windows.Forms;

namespace ChessRelease.Application.Models;

public abstract class Steps
{
    private static Button StepColor(Button butt)
    {
        butt.BackColor = Color.Yellow;
        butt.Enabled = true;
        return butt;
    }

    public static Button[,] StepsWall(int icurrFigure, int jcurrFigure, int currFigure, int[,] map, Button[,] buttons)
    {
        for (var g = jcurrFigure + 1; Check.InsideBorder(icurrFigure, g); g++) //право по прямой
        {
            if (map[icurrFigure, g] % 10 == 1) break;
            if (map[icurrFigure, g] / 10 == 0)
            {
                buttons[icurrFigure, g] = StepColor(buttons[icurrFigure, g]);
                continue;
            }

            if (map[icurrFigure, g] / 10 != currFigure / 10)
            {
                buttons[icurrFigure, g] = StepColor(buttons[icurrFigure, g]);
                break;
            }

            if (map[icurrFigure, g] / 10 == currFigure / 10) break;
        }

        for (var g = jcurrFigure - 1; Check.InsideBorder(icurrFigure, g); g--) //влево по прямой
        {
            if (map[icurrFigure, g] % 10 == 1) break;
            if (map[icurrFigure, g] / 10 == 0)
            {
                buttons[icurrFigure, g] = StepColor(buttons[icurrFigure, g]);
                continue;
            }

            if (map[icurrFigure, g] / 10 != currFigure / 10)
            {
                if (map[icurrFigure, g] % 10 == 1) break;
                buttons[icurrFigure, g] = StepColor(buttons[icurrFigure, g]);
                break;
            }

            if (map[icurrFigure, g] / 10 == currFigure / 10) break;
        }

        for (var g = icurrFigure - 1; Check.InsideBorder(g, jcurrFigure); g--) //вниз по прямой
        {
            if (map[g, jcurrFigure] % 10 == 1) break;
            if (map[g, jcurrFigure] / 10 == 0)
            {
                buttons[g, jcurrFigure] = StepColor(buttons[g, jcurrFigure]);
                continue;
            }

            if (map[g, jcurrFigure] / 10 != currFigure / 10)
            {
                if (map[g, jcurrFigure] % 10 == 1) break;
                buttons[g, jcurrFigure] = StepColor(buttons[g, jcurrFigure]);
                break;
            }

            if (map[g, jcurrFigure] / 10 == currFigure / 10) break;
        }

        for (var g = icurrFigure + 1; Check.InsideBorder(g, jcurrFigure); g++) //вверх по прямой
        {
            if (map[g, jcurrFigure] % 10 == 1) break;
            if (map[g, jcurrFigure] / 10 == 0)
            {
                buttons[g, jcurrFigure] = StepColor(buttons[g, jcurrFigure]);
                continue;
            }

            if (map[g, jcurrFigure] / 10 != currFigure / 10)
            {
                buttons[g, jcurrFigure] = StepColor(buttons[g, jcurrFigure]);
                break;
            }

            if (map[g, jcurrFigure] / 10 == currFigure / 10) break;
        }

        return buttons;
    }

    public static int[] StepsWall(int icurrFigure, int jcurrFigure, int[,] map)
    {
        int[] tmp = { -1, -1 };
        var player = map[icurrFigure, jcurrFigure] / 10;
        for (var g = jcurrFigure + 1; Check.InsideBorder(icurrFigure, g); g++) //право по прямой
        {
            if (map[icurrFigure, g] % 10 == 1 && player != map[icurrFigure, g] / 10)
            {
                tmp[0] = icurrFigure;
                tmp[1] = g;
                return tmp;
            }

            if (map[icurrFigure, g] % 10 != 0) break;
        }

        for (var g = jcurrFigure - 1; Check.InsideBorder(icurrFigure, g); g--) //влево по прямой
        {
            if (map[icurrFigure, g] % 10 == 1 && player != map[icurrFigure, g] / 10)
            {
                tmp[0] = icurrFigure;
                tmp[1] = g;
                return tmp;
            }

            if (map[icurrFigure, g] % 10 != 0) break;
        }

        for (var g = icurrFigure - 1; Check.InsideBorder(g, jcurrFigure); g--) //вверх по прямой
        {
            if (map[g, jcurrFigure] % 10 == 1 && player != map[g, jcurrFigure] / 10)
            {
                tmp[0] = g;
                tmp[1] = jcurrFigure;
                return tmp;
            }

            if (map[g, jcurrFigure] % 10 != 0) break;
        }

        for (var g = icurrFigure + 1; Check.InsideBorder(g, jcurrFigure); g++) //вниз по прямой
        {
            if (map[g, jcurrFigure] % 10 == 1 && player != map[g, jcurrFigure] / 10)
            {
                tmp[0] = g;
                tmp[1] = jcurrFigure;
                return tmp;
            }

            if (map[g, jcurrFigure] % 10 != 0) break;
        }

        return tmp;
    }

    public static int[] StepsDiagonal(int icurrFigure, int jcurrFigure, int[,] map)
    {
        var j = jcurrFigure;
        int[] tmp = { -1, -1 };
        var player = map[icurrFigure, jcurrFigure] / 10;

        for (var i = icurrFigure + 1; Check.InsideBorder(i, j + 1); i++) //по диагонали
        {
            j++;
            if (map[i, j] % 10 == 1 && player != map[i, j] / 10)
            {
                tmp[0] = i;
                tmp[1] = j;
                return tmp;
            }

            if (map[i, j] % 10 != 0) break;
        }

        j = jcurrFigure;
        for (var i = icurrFigure + 1; Check.InsideBorder(i, j - 1); i++) // по диагонали
        {
            j--;
            if (map[i, j] % 10 == 1 && player != map[i, j] / 10)
            {
                tmp[0] = i;
                tmp[1] = j;
                return tmp;
            }

            if (map[i, j] % 10 != 0) break;
        }

        j = jcurrFigure;
        for (var i = icurrFigure - 1; Check.InsideBorder(i, j + 1); i--) // по диагонали
        {
            j++;
            if (map[i, j] % 10 == 1 && player != map[i, j] / 10)
            {
                tmp[0] = i;
                tmp[1] = j;
                return tmp;
            }

            if (map[i, j] % 10 != 0) break;
        }

        j = jcurrFigure;
        for (var i = icurrFigure - 1; Check.InsideBorder(i, j - 1); i--) // по диагонали
        {
            j--;
            if (map[i, j] % 10 == 1 && player != map[i, j] / 10)
            {
                tmp[0] = i;
                tmp[1] = j;
                return tmp;
            }

            if (map[i, j] % 10 != 0) break;
        }

        return tmp;
    }

    public static Button[,] StepsDiagonal(int icurrFigure, int jcurrFigure, int currFigure, int[,] map,
        Button[,] buttons)
    {
        var j = jcurrFigure;
        for (var i = icurrFigure + 1; Check.InsideBorder(i, j + 1); i++) //по диагонали
        {
            j++;
            if (map[i, j] / 10 == 0)
            {
                buttons[i, j] = StepColor(buttons[i, j]);
                continue;
            }

            if (map[i, j] / 10 != currFigure / 10)
            {
                if (map[i, j] % 10 == 1) break;
                buttons[i, j] = StepColor(buttons[i, j]);
                break;
            }

            if (map[i, j] / 10 == currFigure / 10) break;
        }

        j = jcurrFigure;
        for (var i = icurrFigure + 1; Check.InsideBorder(i, j - 1); i++) // по диагонали
        {
            j--;
            if (map[i, j] / 10 == 0)
            {
                buttons[i, j] = StepColor(buttons[i, j]);
                continue;
            }

            if (map[i, j] / 10 != currFigure / 10)
            {
                if (map[i, j] % 10 == 1) break;
                buttons[i, j] = StepColor(buttons[i, j]);
                break;
            }

            if (map[i, j] / 10 == currFigure / 10) break;
        }

        j = jcurrFigure;
        for (var i = icurrFigure - 1; Check.InsideBorder(i, j + 1); i--) // по диагонали
        {
            j++;
            if (map[i, j] / 10 == 0)
            {
                buttons[i, j] = StepColor(buttons[i, j]);
                continue;
            }

            if (map[i, j] / 10 != currFigure / 10)
            {
                if (map[i, j] % 10 == 1) break;
                buttons[i, j] = StepColor(buttons[i, j]);
                break;
            }

            if (map[i, j] / 10 == currFigure / 10) break;
        }

        j = jcurrFigure;
        for (var i = icurrFigure - 1; Check.InsideBorder(i, j - 1); i--) // по диагонали
        {
            j--;
            if (map[i, j] / 10 == 0)
            {
                buttons[i, j] = StepColor(buttons[i, j]);
                continue;
            }

            if (map[i, j] / 10 != currFigure / 10)
            {
                if (map[i, j] % 10 == 1) break;
                buttons[i, j] = StepColor(buttons[i, j]);
                break;
            }

            if (map[i, j] / 10 == currFigure / 10) break;
        }

        return buttons;
    }

    public static Button[,] StepHorse(int icurrFigure, int jcurrFigure, int currFigure, int[,] map, Button[,] buttons)
    {
        var dir = currFigure / 10 == 1 ? 1 : -1;
        if (Check.InsideBorder(icurrFigure + 2 * dir, jcurrFigure - 1)) // вниз влево
            if (map[icurrFigure + 2 * dir, jcurrFigure - 1] / 10 != currFigure / 10 &&
                map[icurrFigure + 2 * dir, jcurrFigure - 1] % 10 != 1)
                buttons[icurrFigure + 2 * dir, jcurrFigure - 1] =
                    StepColor(buttons[icurrFigure + 2 * dir, jcurrFigure - 1]);
        if (Check.InsideBorder(icurrFigure + 2 * dir, jcurrFigure + 1)) // вниз вправо
            if (map[icurrFigure + 2 * dir, jcurrFigure + 1] / 10 != currFigure / 10 &&
                map[icurrFigure + 2 * dir, jcurrFigure + 1] % 10 != 1)
                buttons[icurrFigure + 2 * dir, jcurrFigure + 1] =
                    StepColor(buttons[icurrFigure + 2 * dir, jcurrFigure + 1]);
        if (Check.InsideBorder(icurrFigure - 2 * dir, jcurrFigure + 1)) // вверх вправо
            if (map[icurrFigure - 2 * dir, jcurrFigure + 1] / 10 != currFigure / 10 &&
                map[icurrFigure - 2 * dir, jcurrFigure + 1] % 10 != 1)
                buttons[icurrFigure - 2 * dir, jcurrFigure + 1] =
                    StepColor(buttons[icurrFigure - 2 * dir, jcurrFigure + 1]);
        if (Check.InsideBorder(icurrFigure - 2 * dir, jcurrFigure - 1)) // вверх влево
            if (map[icurrFigure - 2 * dir, jcurrFigure - 1] / 10 != currFigure / 10 &&
                map[icurrFigure - 2 * dir, jcurrFigure - 1] % 10 != 1)
                buttons[icurrFigure - 2 * dir, jcurrFigure - 1] =
                    StepColor(buttons[icurrFigure - 2 * dir, jcurrFigure - 1]);
        return buttons;
    }

    public static bool StepHorse(int icurrFigure, int jcurrFigure, int currFigure, int[,] map)
    {
        var dir = currFigure / 10 == 1 ? 1 : -1;
        if (Check.InsideBorder(icurrFigure + 2 * dir, jcurrFigure - 1)) // вниз влево
            if (map[icurrFigure + 2 * dir, jcurrFigure - 1] / 10 != currFigure / 10 &&
                map[icurrFigure + 2 * dir, jcurrFigure - 1] % 10 == 1)
                return true;
        if (Check.InsideBorder(icurrFigure + 2 * dir, jcurrFigure + 1)) // вниз вправо
            if (map[icurrFigure + 2 * dir, jcurrFigure + 1] / 10 != currFigure / 10 &&
                map[icurrFigure + 2 * dir, jcurrFigure + 1] / 10 % 10 == 1)
                return true;
        if (Check.InsideBorder(icurrFigure - 2 * dir, jcurrFigure + 1)) // вверх вправо
            if (map[icurrFigure - 2 * dir, jcurrFigure + 1] / 10 != currFigure / 10 &&
                map[icurrFigure - 2 * dir, jcurrFigure + 1] % 10 == 1)
                return true;
        if (Check.InsideBorder(icurrFigure - 2 * dir, jcurrFigure - 1)) // вверх влево
            if (map[icurrFigure - 2 * dir, jcurrFigure - 1] / 10 != currFigure / 10 &&
                map[icurrFigure - 2 * dir, jcurrFigure - 1] / 10 % 10 == 1)
                return true;
        return false;
    }

    public static Button[,] StepFigure(int icurrFigure, int jcurrFigure, int currFigure, int[,] map, Button[,] buttons)
    {
        var dir = currFigure / 10 == 1 ? 1 : -1;
        if (Check.InsideBorder(icurrFigure + 1 * dir, jcurrFigure - 1))
            if (map[icurrFigure + 1 * dir, jcurrFigure - 1] != 0 &&
                map[icurrFigure + 1 * dir, jcurrFigure - 1] / 10 !=
                currFigure / 10) // пешка бьёт в сторону, если не  пусто и не его союзник
                buttons[icurrFigure + 1 * dir, jcurrFigure - 1] =
                    StepColor(buttons[icurrFigure + 1 * dir, jcurrFigure - 1]);

        if (Check.InsideBorder(icurrFigure + 1 * dir, jcurrFigure + 1))
            if (map[icurrFigure + 1 * dir, jcurrFigure + 1] != 0 &&
                map[icurrFigure + 1 * dir, jcurrFigure + 1] / 10 != currFigure / 10)
                buttons[icurrFigure + 1 * dir, jcurrFigure + 1] =
                    StepColor(buttons[icurrFigure + 1 * dir, jcurrFigure + 1]);

        if (Check.InsideBorder(icurrFigure + 1 * dir, jcurrFigure))
        {
            if (map[icurrFigure + 1 * dir, jcurrFigure] == 0)
                buttons[icurrFigure + 1 * dir, jcurrFigure] = StepColor(buttons[icurrFigure + 1 * dir, jcurrFigure]);
            if (Check.InsideBorder(icurrFigure + 2 * dir, jcurrFigure))
                if ((icurrFigure == 1 || icurrFigure == 6) && currFigure % 10 == 6)
                    buttons[icurrFigure + 2 * dir, jcurrFigure] =
                        StepColor(buttons[icurrFigure + 2 * dir, jcurrFigure]);
        }

        return buttons;
    }

    public static bool StepFigure(int icurrFigure, int jcurrFigure, int currFigure, int[,] map)
    {
        var dir = currFigure / 10 == 1 ? 1 : -1;
        if (Check.InsideBorder(icurrFigure + 1 * dir, jcurrFigure - 1))
            if (map[icurrFigure + 1 * dir, jcurrFigure - 1] != 0 &&
                map[icurrFigure + 1 * dir, jcurrFigure - 1] / 10 != currFigure / 10 &&
                map[icurrFigure + 1 * dir, jcurrFigure - 1] % 10 ==
                1) // пешка бьёт в сторону, если не  пусто и не его союзник
                return true;

        if (Check.InsideBorder(icurrFigure + 1 * dir, jcurrFigure + 1))
            if (map[icurrFigure + 1 * dir, jcurrFigure + 1] != 0 &&
                map[icurrFigure + 1 * dir, jcurrFigure + 1] / 10 != currFigure / 10 &&
                map[icurrFigure + 1 * dir, jcurrFigure + 1] % 10 == 1)
                return true;
        return false;
    }
}