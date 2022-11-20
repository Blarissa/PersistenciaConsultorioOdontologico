using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervalo
{
    public class Intervalo 
    {
        public DateTime Inicial { get; private set; }
        public DateTime Final { get; private set; }
        
        public TimeSpan Duracao { get => Final - Inicial ; }

        public Intervalo(DateTime inicial, DateTime final )
        {
            Inicial = inicial;
            Final = final;
            
            if(Inicial.CompareTo(Final) > 0)
            {
                throw new ArgumentException("Data/hora inicial > data/hora final");
            }
        }

    }
}
