using Calmo.Core.Validator;
using MySql.Data.MySqlClient;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace Desafio.Data
{
    internal class DBConfig
    {
        public const int DefaultPort = 5432;
        public string Host { get =>"localhost"; }
        public string User { get =>"postgres"; }
        public string Database { get => "ConsultorioDB"; }
        public string Senha { get => "mypass"; }

        
    }
}