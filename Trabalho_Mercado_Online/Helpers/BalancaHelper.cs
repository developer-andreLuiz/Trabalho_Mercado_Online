using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Trabalho_Mercado_Online.Helpers
{
    class BalancaHelper
    {
        /// <summary>
        /// Configura e abre a porta serial
        /// </summary>
        /// <param name="porta">Porta de Comunicação Serial (COM1, COM2, COM3, COM4)</param>
        /// <param name="baudRate">Opções de BaudRate (0 = 2400, 1 = 4800, 2 = 9600, 3 = 1200, 4 = 19200)</param>
        /// <param name="DataBits">Opções de Data Bits(0 = 7 bits, 1 = 8 bits)</param>
        /// <param name="Paridade">Opção de Paridade( 0 = Nenhuma, 1 = Ímpar, 2 = Par, 3 = Espaço)</param>
        /// <returns>1 = OK.      Transmissão realizada com sucesso. 0 = Erro.      Falha na comunicação.</returns>
        [DllImport("P05.dll")] static extern int AbrePorta(int Porta, int BaudRate, int DataBits, int Paridade);
        /// <summary>
        /// Fecha a porta serial (Não possui parametros)
        /// </summary>
        /// <returns>1 = OK.      Transmissão realizada com sucesso. 0 = Erro.      Falha na comunicação.</returns>
        [DllImport("P05.dll")] static extern int FechaPorta();
        /// <summary>
        /// Pega o peso atual a partir da porta serial utilizada.
        /// </summary>
        /// <param name="OpcaoEscrita">Opções para salvar os arquivos com o pesos (Arquivo TXT = 0 Àrea de Transferência = 1)</param>
        /// <param name="PedeTara">0= Não pede tara</param>
        /// <param name="DadosPeso">Dados do Peso</param>
        /// <param name="Local">Local onde será salvo o arquivo texto.Ele sempre será gravado como PESO.TXT</param>
        /// <returns>1 = OK.      Transmissão realizada com sucesso. 0 = Erro.      Falha na comunicação.</returns>
        [DllImport("P05.dll")] static extern int PegaPeso(int OpcaoEscrita, byte[] DadosPeso, string Local);
        public static bool PortaAberta = false;
        private readonly object sendKeys;

        private struct CONSTANTES
        {
            public const int porta = 1; //COM1
            public const int baudRate = 0; //2400
            public const int dataBits = 0; // 7 Bits
            public const int paridade = 2; //Par
            public const string ArquivoSinalizacao = "OK.TXT";
        }
        static string ListaBytesParaString(byte[] lista)
        {
            char[] retornoChar = new char[lista.Length];
            for (int i = 0; i < lista.Length; i++)
            {
                retornoChar[i] = (char)lista[i];
            }
            string retorno = new string(retornoChar);
            return retorno.Substring(0, 2) + retorno.Substring(2);
            //return retorno.Substring(0, 2) + "," + retorno.Substring(2);
        }
        public static void AbrirPortaBalanca()
        {
            if (PortaAberta==false)
            {
                try
                {
                    if (AbrePorta(CONSTANTES.porta, CONSTANTES.baudRate, CONSTANTES.dataBits, CONSTANTES.paridade) == 1)
                    {
                        PortaAberta = true;
                    }
                }
                catch 
                {
                    try
                    {
                        FecharPortaBalanca();
                    }
                    catch { }
                }
            }
            

        }
        public static void FecharPortaBalanca()
        {
            try
            {
                if (PortaAberta)
                {
                    FechaPorta();
                    PortaAberta = false;

                }
            }
            catch { }

        }
        public static string CapturarPeso()
        {
            string txt = "00000";
            try
            {
                if (PortaAberta)
                {
                    byte[] DadosPeso = new byte[5]; //5 bytes + nulo

                    String caminho = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                    if (PegaPeso(0, DadosPeso, caminho) == 1)
                    {
                        txt = ListaBytesParaString(DadosPeso);
                    }
                }
            }
            catch { }
            return txt;
        }
        public static string Peso()
        {
            AbrirPortaBalanca();
            string txt = CapturarPeso();
            return txt;
        }
    }
}
