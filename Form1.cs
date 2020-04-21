﻿using System;
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
        const int fieldSize = 30;
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            mySnakeLogic = new SnakeLogic(20,15);
            mySnakeLogic.SnakeMoved += MySnakeLogic_SnakeMoved; ///przepisywanie metody obslugującej

            pictureBoxSnakeBoard.Image = new Bitmap(mySnakeLogic.Width * fieldSize+1, mySnakeLogic.Height * fieldSize+1); ///tworzenie bitmapu
            graphics = Graphics.FromImage(pictureBoxSnakeBoard.Image);

            RepaintBoard();
        }

        private void MySnakeLogic_SnakeMoved()
        {
            RepaintBoard(); //odresowanie płanszy
        }

        private void RepaintBoard()
        {
            graphics.Clear(Color.LightGreen);

            for(int x = 0;x<mySnakeLogic.Width;x++)
            {
                for(int y=0;y<mySnakeLogic.Height;y++)
                {
                    graphics.DrawRectangle(new Pen(Color.Green), x * fieldSize, y * fieldSize, fieldSize, fieldSize); ///polozenie kwadratików na plansze
                }
            }

            graphics.FillEllipse(new SolidBrush(Color.GreenYellow),
                                 mySnakeLogic.Snake.X*fieldSize,
                                 mySnakeLogic.Snake.Y*fieldSize,
                                 fieldSize,
                                 fieldSize);  ///narysowanie snake

            pictureBoxSnakeBoard.Refresh(); ///odresowanie ,żeby snake bigł
        }
    }
}
