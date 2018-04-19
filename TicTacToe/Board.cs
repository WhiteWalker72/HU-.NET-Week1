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
        private bool oIsPlaying;

        public Board()
        {
            InitializeComponent();
            ResetBoard();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button) sender;
                int btnNumber = StringUtils.GetStringInteger(button.Name);

                if (engine.ChooseCell(btnNumber))
                {
                    oIsPlaying = !oIsPlaying;
                    button.Text = oIsPlaying ? "X" : "O";

                    if (engine.GameFinished())
                    {
                        String playerWon = engine.Status.Equals(GameStatus.PlayerOWins) ? "O" : "X";
                        MessageBox.Show("Player " + playerWon + " won! The game is restarting.");

                        engine.Reset();
                        ResetBoard();
                    }
                }
            } 
        }

        private void ResetBoard()
        {
            oIsPlaying = true;
            foreach (Component comp in Controls)
            {
                if (comp is Button)
                {
                    Button btn = (Button) comp;
                    btn.Text = StringUtils.GetStringInteger(btn.Name).ToString();
                }
            }
        }

        private void Board_Load(object sender, EventArgs e)
        {

        }
    }
}
