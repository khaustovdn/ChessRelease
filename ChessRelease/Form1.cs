using System.Windows.Forms;
using ChessRelease.Application.Models;

namespace ChessRelease;

public partial class Form1 : Form
{
    public Form1()
    {
        board = new Board();
        InitializeComponent();
        CreateMap();
    }

    public Board board { get; set; }

    public void CreateMap()
    {
        for (var i = 0; i < 8; i++)
        for (var j = 0; j < 8; j++)
            Controls.Add(board.CreateButton(i, j));
    }
}