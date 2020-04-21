using System;
using System.Collections.Generic;
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

        Timer timer = new Timer(); ///deklaracja timera

        public SnakeLogic()
        {
            ///konfiguracja taimera
            timer.Enabled = true;
            timer.Interval = 200;

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(SnakeMoved != null) ///zeby nie było błąda na wartość null
            {
                SnakeMoved(); ///wywolujemy zdarzenie
            }

        }
    }
}
