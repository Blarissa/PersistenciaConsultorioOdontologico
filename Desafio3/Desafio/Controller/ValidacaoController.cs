using Desafio.Model;
using System.Globalization;
using Desafio.Data;
using Desafio.View.Mensagens;
using System.Text.RegularExpressions;
using Desafio.Data.DAO;
using System;

namespace Desafio.Controller

{    /// <summary>
     /// Define a validadação de todos dados do <see cref="Paciente"/> e da <see cref="ConsultaController"/>.
     /// </summary>
    public class ValidacaoController
    {

        private ValidacaoDAO ValidacaoDB { get; set; }

        public ValidacaoController(ConsultorioContexto consultorioCtxt)
        {
            ValidacaoDB = new(consultorioCtxt);
        }


        /// <summary>
        /// Validação do <see cref = "Paciente.CPF" />.
        /// </ summary >
        ///< param name = "CPF">Representa o valor de um<see langword="CPF"/> que deve ser validado.</param>        
        ///<returns>
        ///<list type = "bullet" >
        ///< item >
        /// Retorna < see langword="false"/>:
        ///<list type = "bullet" >
        ///< item > Se o valor do <see langword = "CPF" /> for nulo ou vazio;</item>
        ///<item>Se o<see langword= "CPF" /> não tiver 11 dígitos;</item>
        ///<item>Se o valor de todos os dígitos do <see langword = "CPF" /> forem iguais;Ou</item>
        ///<item>Se o valor<see langword="CPF"/> for um<see langword="CPF"/> de valor inexistente.</item>
        ///</list>
        ///</item>
        ///<item>Retorna<see langword="true"/> se o valor do <see langword = "CPF" /> for um<see langword="CPF"/> de valor que existente.</item>
        ///</list>
        ///</returns>
        public bool ValidaCpf(string? CPF)
        {
            if (string.IsNullOrEmpty(CPF) && !CPF.Length.Equals(11) ||
                CPF.All(c => CPF[0].Equals(c)))
            {
                Console.WriteLine(MenssagemDeErro.CpfInvalido);
                return false;
            }

            int somaJ = 0, somaK = 0;
            int i = 10;
            foreach (char s in CPF.Substring(0, 9))
            {
                somaJ += (int)char.GetNumericValue(s) * i;
                i--;
            }

            i = 11;
            foreach (char s in CPF.Substring(0, 10))
            {
                somaK += (int)char.GetNumericValue(s) * i;
                i--;
            }

            int restoJ = somaJ % 11;
            int restoK = somaK % 11;

            bool valorJ = false;
            bool valorK = false;

            if (restoJ == 0 || restoJ == 1)
                valorJ = (int)Char.GetNumericValue(CPF[9]) == 0;
            else if (restoJ >= 2 && restoJ <= 10)
                valorJ = (int)Char.GetNumericValue(CPF[9]) == (11 - restoJ);

            if (restoK == 0 || restoK == 1)
                valorK = (int)Char.GetNumericValue(CPF[10]) == 0;
            else if (restoK >= 2 && restoK <= 10)
                valorK = (int)Char.GetNumericValue(CPF[10]) == (11 - restoK);

            if (!(valorJ || valorK))
            {
                Console.WriteLine(MenssagemDeErro.CpfInvalido);
                return false;
            }
            return true;
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //===================================================VALIDACOES DATA====================================================

        

        /// <summary>
        /// Validação da <see cref="Consulta.DtConsulta"/>.
        /// </summary>
        ///<param name = "datas">Representa o valor de todas as <see langword="datas"/> na qual exitem pelo menos uma <see cref="Consulta"/> agentada.</param>        
        ///<param name = "data">Representa o valor de uma <see langword="data da consulta"/> que deve ser validada.</param>        
        ///<returns>
        ///<list type="bullet">
        ///<item>
        ///Retorna <see langword="false"/> e exibe menssagem de erro:
        ///<list type="bullet">
        ///<item>Se o valor da <see langword="data"/> não estiver no formato DD/MM/AAAA;Ou</item>
        ///<item>Se o valor da <see langword="data"/> não estiver em um período futuro;</item>        
        ///</list>
        ///</item>
        ///<item>Retorna <see langword="true"/> se não retornar <see langword="false"/>.</item>
        ///</list>
        ///</returns>
        private bool ValidaDataConsulta(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }

            DateTime dataConsulta = DateTime.Parse(data);

            if (dataConsulta.CompareTo(DateTime.Today) < 0)
            {
                Console.WriteLine(MenssagemDeErro.DtConsultaInvalida);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validação do formato da <see langword ="data"/>.
        /// </summary>
        ///<param name = "data">Representa o valor da <see langword="data"/> que deve estar no formato correto.</param>                
        ///<returns>
        ///<list type="bullet">
        ///<item>Retorna <see langword="false"/> e exibe menssagem de erro.</item>        
        ///<item>Retorna <see langword="true"/> e exibe menssagem de erro.</item>        
        ///</list>
        ///</returns>
        private bool ValidaDataFormato(String? data)
        {
            return DateTime.TryParse(data, out DateTime dt);
        }

        //Valida data inicial
        private bool ValidaDataInicial(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }

            return DateTime.Parse(data) < DateTime.Now;
        }

        //Valida data final
        private bool ValidaDataFinal(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }

            if (DateTime.Parse(data) >= DateTime.Now)
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFinal);
                return false;
            }

            return true;
        }

        //Valida da data de nascimento
        private bool ValidaDataNascimento(string? data)
        {
            if (!ValidaDataFormato(data))
            {
                Console.WriteLine(MenssagemDeErro.DtInvalidaFormato);
                return false;
            }
            if (!(DateTime.Now.Subtract(DateTime.Parse(data)).Days / 365 >= 13))
            {
                Console.WriteLine(MenssagemDeErro.IdadeInvalida);
                return false;
            }
            return true;
        }

        public bool ValidaData(TipoDeData tipo, string data)
        {
            switch(tipo) {
                case TipoDeData.DataDeNascimento: return ValidaDataNascimento(data);
                case TipoDeData.DataConsulta: return ValidaDataConsulta(data);
                case TipoDeData.DataInicialPeriodo: return ValidaDataInicial(data);
                default: {
                        Console.WriteLine(MenssagemDeErro.DtInvalida);
                        return false;
                    }
            }
        }

        public bool ValidaDataFinal(TipoDeData tipo, DateTime dtInicial, string dtFinal)
        {
            throw new NotImplementedException();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //===================================================VALIDACOES HORA====================================================


        private bool ValidaHrInicialAux(DateTime hrInicial)
        {
            if(ValidacaoDB.QtdConsultasConflituosasHoraInicial(hrInicial) > 0) {
                Console.WriteLine(MenssagemDeErro.HrInvalidaConflito);
                return false;
            }

            return true;
        }

        //Valida hora final
        private bool ValidaHrFinalAux(DateTime hrInicial, DateTime hrFinal)
        {

            //Valida a Hora final de acordo com as regras de agendamento
            if (hrFinal.TimeOfDay <= hrInicial.TimeOfDay)
            {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFinal);
                return false;
            }

            if(ValidacaoDB.QtdConsultasConflituosasHoraFinal(hrFinal) > 0) {
                Console.WriteLine(MenssagemDeErro.HrInvalidaConflito);
                return false;
            }


            return true;
        }

        //Valida o formato da hora
        private bool ValidaHoraFormato(string? horario)
        {
            Regex rx = new Regex(@"(^\d{2}:\d{2}$)");
            if(!rx.Match(horario).Success) {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFormato);
                return false;
            }

            try {
                short min = Convert.ToInt16(horario.Substring(3));
                short hora = Convert.ToInt16(horario.Substring(0, 2));

                if(min % 15 != 0 || min >= 60) {
                    Console.WriteLine(MenssagemDeErro.HrInvalidaMultiplos);
                    return false;
                }

                if(hora < 8 || hora > 19) {
                    Console.WriteLine(MenssagemDeErro.HrInvalidaFuncionamento);
                    return false;
                }

                return true;
            }
            catch {
                Console.WriteLine(MenssagemDeErro.HrInvalidaFormato);
                return false;
            }
        }

        public bool ValidaHoraInicial(TipoDeHora tipo, DateTime data, string? hora)
        {
            if(!ValidaHoraFormato(hora)) {
                return false;
            }

            DateTime tempoCompleto = data + DateTime.ParseExact(hora, "HH:mm", new CultureInfo("pt-BR")).TimeOfDay;

            switch(tipo) {
                case TipoDeHora.HoraInicial: return ValidaHrInicialAux(tempoCompleto);

                default: return false;
            }
        }

        public bool ValidaHoraFinal(DateTime data, DateTime horaInicial, string? hora)
        {
            if(!ValidaHoraFormato(hora)) {
                return false;
            }

            DateTime tempoCompleto = data + DateTime.ParseExact(hora, "HH:mm", new CultureInfo("pt-BR")).TimeOfDay;

            return ValidaHrFinalAux(horaInicial, tempoCompleto);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Valida do nome
        public bool ValidaNome(string? nome)
        {
            if (nome.Length < 5)
            {
                Console.WriteLine(MenssagemDeErro.NomeInvalido);
                return false;
            }
            return true;
        }

        //Valida opção de listagem de agenda
        public bool ValidaOpcaoListAgenda(string? opcao)
        {
            Regex rx = new Regex(@"(^[TPtp])");
            if(!rx.Match(opcao.ToUpper()).Success) {
                Console.WriteLine(MenssagemDeErro.OpcaoInvalida);
                return false;
            }

            return true;
        }

        public bool PacienteExiste(long cpf)
        {
            Paciente p = ValidacaoDB.ListarPacientePorCPF(cpf);
            if (p == null) {
                Console.WriteLine(MenssagemDeErro.CpfInexistente);
                return false;
            }

            return true;
        }
    }
}
