using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeLibrary;
using TicTacToe.Utils;

namespace TicTacToe
{
    public partial class Board : Form
    {
        private readonly TicTacToeEngine engine = new TicTacToeEngine();

        public Board()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button) sender;
                int btnNumber = StringUtils.GetStringInteger(button.Name);
                char symbol = engine.GetCurrentPlayer().GetSymbol();

                if (engine.ChooseCell(btnNumber))
                {
                    button.Text = symbol.ToString();

                    if (engine.GameFinished())
                    {
                        String endText = engine.Status.ToString().ToLower().Contains("won") ? "Player " + engine.GetCurrentPlayer().GetSymbol() + " won!" : "The game ended in a draw.";
                        MessageBox.Show(endText + " The game is restarting.");
                        engine.Reset();
                        ResetBoard();
                    }
                }
            } 
        }

        private void ResetBoard()
        {
            foreach (Control control in Controls) {
                if (control is Button)
                {
                    control.Text = "";
                }
            }
        }

        private void Board_Load(object sender, EventArgs e)
        {

        }
    }
}
