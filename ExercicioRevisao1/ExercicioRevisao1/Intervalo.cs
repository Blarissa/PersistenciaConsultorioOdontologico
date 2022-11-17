using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioRevisao1
{

    /*
     * Crie a classe Intervalo para representar um intervalo de tempo com data/hora 
     * inicial e final. Dica:use Datetime. Nessa classe implemente:
    
    Construtor para inicializar a data/hora inicial e final. 
    Gere uma exceção caso data/hora inicial data/hora final.
    
    Data/hora inicial e final não podem ser alterados.
    
    Método booleano TemIntersecao que verifica se um intervalo tem interseção com outro
    intervalo ou não.
    
    Método para verificar se dois intervalos são iguais.
    
    Propriedade Duracao para retornar a duração de um intervalo. Dica: use TimeSpan.
     */
    internal class Intervalo
    {
        public DateTime Inicial {
            get;set;
        }
        public DateTime Final {
            get;set;
        }
        
        public TimeSpan Duracao { 
            get {
                return Final - Inicial;
            }
        }

        public Intervalo(DateTime inicial, DateTime final )
        {
            Inicial = inicial;
            Final = final;
            
            if(inicial > Final)
            {
                throw new ArgumentException("Data/hora inicial > data/hora final");
            }
        }
    }
}
