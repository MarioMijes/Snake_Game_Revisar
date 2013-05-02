using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//Este programa fue basado en el tutorial: http://www.youtube.com/watch?v=mLIB60wG_AI 
//de: TutorialHouseNz
namespace Snake_Game
{
    public partial class Form1 : Form
    {
        //Creación del Juego (Serpiente Inicial, Comida, Matriz 29x29)
        Random RComida = new Random();
        Graphics papel;
        Snake snake = new Snake();
        Comida comida;


        //Variables de Movimiento
        bool izq = false;
        bool der = false;
        bool abajo = false;
        bool arriba = false;

        int puntos = 0;

        public Form1()
        {
            InitializeComponent();
            comida = new Comida(RComida);
        }

        //Evento Paint (Graficos, Comida, Snake)
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            papel = e.Graphics;
            comida.Dibuja_Comida(papel);
            snake.Dibuja_Snake(papel);
        }

        //Eventos de movimiento
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Tecla espacio, inicia el juego)
            if(e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                Start.Text = "";
                abajo = false;
                arriba = false;
                izq = false;
                der = true;

            }

            //Tecla Abajo, Mueve abajo
            if(e.KeyData == Keys.Down && arriba == false)
            {
                abajo = true;
                arriba = false;
                der = false;
                izq = false;
            }

            //Tecla Arriba, Mueve arriba
            if (e.KeyData == Keys.Up && abajo == false)
            {
                abajo = false;
                arriba = true;
                der = false;
                izq = false;
            }

            //Tecla Izquiera, Mueve izquierda
            if (e.KeyData == Keys.Left && der == false)
            {
                abajo = false;
                arriba = false;
                der = false;
                izq = true;
            }

            //Tecla Derecha, Mueve derecha
            if (e.KeyData == Keys.Right && izq == false)
            {
                abajo = false;
                arriba = false;
                der = true;
                izq = false;
            }


        }

        //Timer, Cliclo infinito de las instrucciones dentro de este.
        private void timer1_Tick(object sender, EventArgs e)
        {
            Puntos_Snake.Text = Convert.ToString(puntos);

            //Llamada a los metodos de movimiento
            if (abajo) { snake.mov_Abajo(); }
            if (arriba) { snake.mov_Arriba(); }
            if (izq) { snake.mov_Izquierda(); }
            if (der) { snake.mov_Derecha(); }

            //Cremicimiento al intersectar con la comida
            for (int i = 0; i < snake.Snakerec.Length; i++)
            {
                if (snake.Snakerec[i].IntersectsWith(comida.Comidarec))
                {
                    puntos += 10;
                    snake.Crecimiento_Snake();
                    comida.Lugar_Comida(RComida);
                    if(timer1.Interval <= 10)
                    {
                        timer1.Interval -= 1;
                    }
                }
            }

            Choque();

            this.Invalidate();
        }

        //Metodo para llamar a Comienzo despues de perder
        public void Choque()
        {
            for (int i = 1; i < snake.Snakerec.Length; i++ ) 
            {
                if(snake.Snakerec[0].IntersectsWith(snake.Snakerec[i]))
                {
                    Comienzo();
                }
            }

            if (snake.Snakerec[0].X < 0 || snake.Snakerec[0].X > 290)
            {
                Comienzo();
            }

            if (snake.Snakerec[0].Y < 0 || snake.Snakerec[0].Y > 290)
            {
                Comienzo();
            }
        }

        //Metodo usado para avisar el termino del juego, los puntos y el nuevo inicio
        public void Comienzo()
        {
            timer1.Enabled = false;
            timer1.Interval = 100;
            MessageBox.Show("GAME OVER. Tus Puntos : " + puntos);
            Puntos_Snake.Text = "0";
            puntos = 0;
            Start.Text = "Presiona Barra para empezar";
            snake = new Snake();
        }

        //Evento usado para que el intervalo del timer siempre inicie desde 100
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 100;
        }
    }
}
