using System;

namespace Intervalo
{
    public class ListaIntervalos : List<Intervalo>
    {
    
        //List<Intervalo> intervalos;
        // Intervalo intervalo;

        

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /*public override string ToString()
        {
            List<Intervalo> query = intervalos.OrderBy(i => i.Inicial).ToList();

            String imprime = "dkmk";

            foreach (Intervalo i in query)
                imprime += "Data/Hora Inicial   Data/Hora Final     Intervalo"
                    + "\n" + i.Inicial.ToString("dd/MM/yyyy HH:mm")
                    + "    " + i.Final.ToString("dd/MM/yyyy HH:mm")
                    + "    " + i.Duracao.Days + " dias "
                    + i.Duracao.Hours + ":" + i.Duracao.Minutes
                    + "\n";


            return imprime;
        }
        */
    }
}