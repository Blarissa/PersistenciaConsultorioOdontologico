﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Data.DAO
{
    internal interface IComando<T>
    {
        void Adicionar(T tipo);
        void Remover(T tipo);
        IList<T> ListaTodos();
    }
}
