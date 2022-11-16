using System;
using System.Collections;
using System.Globalization;
using System.Net.Http.Headers;

namespace ExercicioRevisao1
{
    //atribui valores possiveis para tipo do triangulo
    public enum Tipo
    {
        equilatero,isosceles, escaleno
    }

    internal class Triangulo
    {
        public Vertice[] Vertices { get; private set; }

        public double[] Lados { get; private set; }

        public double Perimetro {
            get {
                double p = 0;
                //calcula perimetro do triangulo
                for (int i = 0; i < Lados.Length; i++)
                    p += Lados[i];
                       
                return p;
            }
        }

        public double Area {
            get {
                double S = Perimetro / 2;
                double area = 1;

                //calcula area do triangulo
                for (int i = 0; i < Lados.Length; i++)
                    area *= S - Lados[i];
                
                area = Math.Sqrt(S * area);

                return area;
            }
        }

        public Tipo Tipo {
            get{
                //conta lados iguais
                int cont = 0;

                foreach (double l1 in Lados)
                    if (l1.Equals(Lados[0]))
                    {
                        cont++;
                        break;
                    }
                
                if (cont == 1)
                    return Tipo.escaleno;
                else if (cont == 3)
                    return Tipo.equilatero;
                else
                    return Tipo.isosceles;
            }
        }

        public Triangulo(Vertice[] v)
        {   
            //inicializa vertices dos triangulos
            Vertices = new Vertice[3];
            for(int i = 0; i < v.Length; i++)
            {
                Vertices[i] = v[i];
            }

            //define valor dos lados do triangulo
            Lados = new double[3];
            for (int i = 0,j = i + 1; i < v.Length; i++, j++)
            {
                if(j == 3)
                    j = 0;
                
                Lados[i] = Vertices[i].Distancia(Vertices[j]);
            }

            //verifica se é triangulo e retorna exceção se não for
            if (!ETriangulo())
                throw new ArgumentException("Não é triangulo");
        }

        public bool ETriangulo()
        {
            for (int i = 2, j = 0; i >= 0; i--){
                //soma dos 2 lados opostos a i
                double soma = Lados[j];
                //subtração dos 2 lados opostos a i
                double sub = Lados[j];

                if (i == 1)
                    j = 0;
                else
                    j++;
               
                soma += Lados[j];
                sub -= Lados[j];
                j++;

                //condição de existencia do triangulo
                //|b - c| < a < b + c
                if (Lados[i] < soma && Lados[i] > Math.Abs(sub))
                    return true;
            }
            
            return false;
        }
        
        public bool Diferente(Triangulo t)
        {
            //conta lados iguais
            int cont = 0;
            foreach (double l1 in Lados)
            {
                foreach(double l2 in t.Lados)
                {
                    //para o laço se os lados são iguais
                    if (l1.Equals(l2))
                    {
                        cont++;
                        break;
                    }
                }
            }
            
            if(cont == 3)
                return false;

            return true;
        }
    }
}
