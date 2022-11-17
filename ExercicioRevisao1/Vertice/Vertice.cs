using System;

namespace Formas
{
    internal class Vertice
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        
        //inicializa vertice
        public Vertice(double x, double y)
        {
            
            X = x;
            Y = y;
        }
        
        public Vertice() { }
        //calcula distancia entre 2 vertices
        public double Distancia(Vertice v)
        {
            //precisção de 2 casas
            return Math.Round(
                   Math.Sqrt(
                       Math.Pow((X - v.X),2) + Math.Pow((Y - v.Y), 2)),
                   2);
        }

        //move um vertice para uma cordenada diferente
        public void Move(double x, double y)
        {
            X = x;
            Y = y;
        }

        //verifica se dois vertices são diferentes
        public bool Diferente(Vertice v)
        {
            if (X == v.X && Y == v.X)
                return false;
            return true;
        }
    }
}
