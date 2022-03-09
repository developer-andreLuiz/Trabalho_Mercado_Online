using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Controllers;


namespace Trabalho_Mercado_Online.Helpers
{
    class GlobalHelper
    {
        public static ListasBancoHelper Listas = new ListasBancoHelper();
       
        public static String CaminhoPastaImagem { get; set; }
        public static List<Thread> Lista_Thread_Imagem = new List<Thread>();
        public static bool Break_Thread = false;

        public static void AtualizarProdutosCategoria()
        {
            Listas.ProdutoCategoria = ProdutoCategoriaController.GetAll();
        }
        public static void AtualizarCategorasNivel1()
        {
            Listas.CategoriaNivel1 = CategoriaNivel1Controller.GetAll();
        }
        public static void AtualizarCategorasNivel2()
        {
            Listas.CategoriaNivel2 = CategoriaNivel2Controller.GetAll();
        }
        public static void AtualizarCategorasNivel3()
        {
            Listas.CategoriaNivel3 = CategoriaNivel3Controller.GetAll();
        }
       
        public static void FinalizarThread()
        {
            for (int i = 0; i < Lista_Thread_Imagem.Count; i++)
            {
                try
                {
                    Lista_Thread_Imagem[i].Abort();
                    Lista_Thread_Imagem.RemoveAt(i);
                }
                catch 
                {
                    try
                    {
                        Lista_Thread_Imagem[i].Interrupt();

                    }
                    catch { }
                    try
                    {
                        Lista_Thread_Imagem[i].Abort();
                        Lista_Thread_Imagem.RemoveAt(i);
                    }
                    catch { }
                }
            }

        }








    }
}
