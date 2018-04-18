using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Board : Form
    {
        public Board()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Er is geklikt!");
            
        }

        private void Board_Load(object sender, EventArgs e)
        {

        }
    }
}
