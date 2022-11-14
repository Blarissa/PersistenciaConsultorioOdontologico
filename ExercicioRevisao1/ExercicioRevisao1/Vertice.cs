using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioRevisao1
{
    internal class Vertice
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vertice() { }

        public Vertice(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public double Distancia(Vertice v1)
        {
            if(Diferente(v1))
            {
                double dist = Math.Pow((v1.X - X),2) + Math.Pow((v1.Y - Y), 2);
                return Math.Sqrt(dist);
            }
            return 0;
            
        }

        public Vertice Move(double x, double y)
        {
            return new Vertice(x,y);
        }

        public bool Diferente(Vertice v1)
        {
            if (X != v1.X || Y != v1.X)
                return true;
            return false;
        }

    }
}
