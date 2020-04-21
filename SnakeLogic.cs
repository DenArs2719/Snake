﻿using System;
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

        internal SnakeDirection Direction 
        { 
            private get => direction;
            set
            {
                direction = value;
                TimerSnakeMove_Tick(null, null);
            }
        }

        public Point Apple { get => apple; set => apple = value; }

        private List<Point> snake;

        private Point apple; ///jabłko

        private Random generator = new Random(); //generowanie jabłek


        public enum SnakeDirection
        {
            Left,
            Right,
            Up,
            Down
        }

        private SnakeDirection direction;

        public SnakeLogic(int width, int height)
        {
            ///rozmiar planszy
            this.Width = width;
            this.Height = height;
         

            Snake = new List<Point>();
            ///ustowianie polozenia snake
            Snake.Add(new Point(width / 2, height - 1));
            Snake.Add(new Point(width / 2, height + 0));
            Snake.Add(new Point(width / 2, height + 1));
            Snake.Add(new Point(width / 2, height + 2));

            Direction = SnakeDirection.Up;

            generateApple();

            ///konfiguracja taimera
            timerSnakeMove.Tick += TimerSnakeMove_Tick;
            timerSnakeMove.Interval = 500;
            timerSnakeMove.Enabled = true;
        }

        private void generateApple()
        {
            Point tmpApple;
            do
            {
                tmpApple = new Point(generator.Next(Width), generator.Next(Height));


            } while (Snake.Contains(tmpApple)); ///do puki snake nie zawiera jabłka

            Apple = tmpApple;
        }

        private void TimerSnakeMove_Tick(object sender, EventArgs e)
        {
            Point newHead = Point.Empty; 

            ///przestawiamy punkt zgodnie z kierunkiem
            switch (direction)
            {
                case SnakeDirection.Left:
                    newHead =  new Point(Snake.First().X - 1, Snake.First().Y);
                    break;
                case SnakeDirection.Right:
                    newHead =  new Point(Snake.First().X + 1, Snake.First().Y);
                    break;
                case SnakeDirection.Up:
                    newHead =  new Point(Snake.First().X, Snake.First().Y - 1);
                    break;
                case SnakeDirection.Down:
                    newHead = new Point(Snake.First().X, Snake.First().Y + 1);
                    break;

            }

            Snake.Insert(0,newHead); //dodowanie do lisy
            if(newHead == Apple)
            {
                generateApple();
                timerSnakeMove.Interval = (int)(timerSnakeMove.Interval * 0.8);
            }
            else
            {
                Snake.Remove(Snake.Last());///usuwamy ostatni punkt
            }


            if (SnakeMoved != null) ///zeby nie było błąda na wartość null
            {
                SnakeMoved(); ///wywolujemy zdarzenie
            }


        }
    }
}
