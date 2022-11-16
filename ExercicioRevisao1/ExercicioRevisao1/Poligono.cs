using System;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace ExercicioRevisao1
{
    internal class Poligono
    {
        public List<Vertice> Vertices { get; private set; }
        public List<double> Lados { get; private set; }
        public int Qtd{
            get{
                return Vertices.Count;
            }
        }

        public Poligono(List<Vertice> v) {
            //inicializa vertices
            Vertices = new List<Vertice>();
            Vertices.AddRange(v);

            Lados = new List<double>();
            AtualizaLados();
            
            if (Qtd < 3){
                throw new ArgumentException("Quantidade de vértices inválida!");
            }
        }
        //adiciona um novo vertice no poligono
        public bool AddVertice(Vertice v) { 
            //se o vertice v já existe retorna falso para adicionar vertice
            if(Vertices.Contains(v))
                return false;

            Vertices.Add(v);
            //atualiza valores dos lados
            AtualizaLados();
           
            return true;
        }

        public void AtualizaLados()
        {
            Lados.Clear();

            for (int i = 0, j = 1; i < Qtd; i++, j++)
            {
                if (j == Qtd - 1)
                    j = 0;

                Lados.Add(Vertices[i].Distancia(Vertices[j]));
            }
        }

        //remove um vértice do polígono. 
        public void Remove(Vertice v)
        {
            if (Vertices.Contains(v)){
                Vertices.Remove(v);
                AtualizaLados();

                if (Qtd < 3)
                    throw new ArgumentException("Quantidade de vértices menor que 3!");
            }    
        }

        //calcula o perímetro do polígono.
        public double Perimetro() {
            double sum = 0;

            foreach (double l in Lados)
                sum += l;

            return sum;
        }
    }
}
