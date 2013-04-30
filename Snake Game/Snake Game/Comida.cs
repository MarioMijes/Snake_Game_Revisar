using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;

namespace Snake_Game
{
    class Comida //Propiedades de la comida
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle Comidarec;

        public Comida(Random RComida) //Creacion random de una comida en la matriz
        {
            x = RComida.Next(0, 29) * 10;
            y = RComida.Next(0, 29) * 10;
            
            brush = new SolidBrush(Color.HotPink); //Pintar la comida

            width = 10;
            height = 10;

            Comidarec = new Rectangle(x, y, width, height);//Construcción del rectangulo de la comida
        }

        public void Lugar_Comida(Random RComida) //Ubicacion random para la comida
        {
            x = RComida.Next(0, 29) * 10;
            y = RComida.Next(0, 29) * 10;
        }

        public void Dibuja_Comida(Graphics Papel) // Relacionar la variable con la coordenada real
        {
            Comidarec.X = x;
            Comidarec.Y = y;

            Papel.FillRectangle(brush, Comidarec);
        }
    }
}
