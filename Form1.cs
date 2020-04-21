using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        SnakeLogic mySnakeLogic;
        public Form1()
        {
            InitializeComponent();
            mySnakeLogic = new SnakeLogic();
            mySnakeLogic.SnakeMoved += MySnakeLogic_SnakeMoved;
        }

        private void MySnakeLogic_SnakeMoved()
        {
            this.Text += "#";
        }
    }
}
