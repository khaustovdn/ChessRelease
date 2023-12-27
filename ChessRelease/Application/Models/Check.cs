namespace ChessRelease.Application.Models;

public class Check
{
    public static bool InsideBorder(int ti, int tj)
    {
        if (ti >= 8 || tj >= 8 || ti < 0 || tj < 0)
            return false;
        return true;
    }
}