using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    class SnakeLogic
    {
        public delegate void SnakeEvent(); ///pokazanie pewnego typu metody
        public event SnakeEvent SnakeMoved; /// dekloracja eventa typu SnakeEvent()

        private Timer timerSnakeMove = new Timer(); ///deklaracja timera

        private int width;
        private int height;

        public int Width { get => width; private set => width = value; }
        public int Height { get => height; private set => height = value; }
        public List<Point> Snake { get => snake; private set => snake = value; }

        private List<Point> snake;
        public SnakeLogic(int width, int height)
        {
            ///rozmiar planszy
            this.Width = width;
            this.Height = height;
            ///konfiguracja taimera
            timerSnakeMove.Enabled = true;
            timerSnakeMove.Interval = 500;

            timerSnakeMove.Tick += TimerSnakeMove_Tick;

            Snake = new List<Point>();
            ///ustowianie polozenia snake
            Snake.Add(new Point(width / 2, height - 1));
            Snake.Add(new Point(width / 2, height + 0));
            Snake.Add(new Point(width / 2, height + 1));
            Snake.Add(new Point(width / 2, height + 2));
        }

        private void TimerSnakeMove_Tick(object sender, EventArgs e)
        {
            Point newHead = new Point(Snake.First().X, Snake.First().Y - 1);

            Snake.Insert(0,newHead); //dodowanie do lisy
            Snake.Remove(Snake.Last());///usuwamy ostatni punkt

            if(SnakeMoved != null) ///zeby nie było błąda na wartość null
            {
                SnakeMoved(); ///wywolujemy zdarzenie
            }


        }
    }
}
