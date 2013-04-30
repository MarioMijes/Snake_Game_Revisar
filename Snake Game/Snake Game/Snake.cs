using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Snake_Game
{

    //Propiedades de la snake
    public class Snake
    {
        private Rectangle[] SnakeRec; // su rectangulo
        private SolidBrush brush; // su brocha
        private int x, y, width, height; // sus coordenadas 

        public Rectangle[] Snakerec // Metodo de la creación del rectangulo
        {
            get { return SnakeRec; }
        }

        public Snake() // Constructor de la Snake
        {
            SnakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.ForestGreen);

            x = 20;
            y = 0;
            width = 10;
            height = 10;

            for (int i = 0; i < SnakeRec.Length; i++)
            {
                SnakeRec[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        
        public void Dibuja_Snake(Graphics papel) //Dibuja la snake
        {
           foreach(Rectangle rec in SnakeRec)
            {
                    papel.FillRectangle(brush, rec);
            }
        }

        public void Dibuja_Snake()
        {
            for (int i = SnakeRec.Length - 1; i > 0; i--)
            {
                SnakeRec[i] = SnakeRec[i - 1];
            }
        }
        //Metodos principales de movimiento en la matriz

        public void mov_Abajo()
        {
            Dibuja_Snake();
            SnakeRec[0].Y += 10;
        }

        public void mov_Arriba()
        {
            Dibuja_Snake();
            SnakeRec[0].Y -= 10;
        }

        public void mov_Izquierda()
        {
            Dibuja_Snake();
            SnakeRec[0].X -= 10;
        }

        public void mov_Derecha()
        {
            Dibuja_Snake();
            SnakeRec[0].X += 10;
        }

        //Lista de rectangulos, se añade un nuevo rectangulo a la fila.
        public void Crecimiento_Snake()
        {
            List<Rectangle> rec = SnakeRec.ToList();
            rec.Add(new Rectangle(SnakeRec[SnakeRec.Length - 1].X, SnakeRec[SnakeRec.Length - 1].Y, width, height));
            SnakeRec = rec.ToArray();
        }
    }
}
