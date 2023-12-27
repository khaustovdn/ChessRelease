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
    }
}