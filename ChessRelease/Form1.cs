using System.Windows.Forms;
using ChessRelease.Application.Models;

namespace ChessRelease;

public partial class Form1 : Form
{
    public Board board { get; set; }
    public Form1()
    {
        board = new Board();
        InitializeComponent();
        CreateMap();
    }
    public void CreateMap()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Controls.Add(board.CreateButton(i, j));
            }
        }
    }
}