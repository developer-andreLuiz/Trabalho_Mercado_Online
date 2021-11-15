using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Trabalho_Mercado_Online.Controllers;


namespace Trabalho_Mercado_Online.Helpers
{
    class Global
    {
        public static ListasBanco Listas = new ListasBanco();
       
        public static String CaminhoPastaImagem { get; set; }
        public static List<Thread> Lista_Thread_Imagem = new List<Thread>();
        public static bool Break_Thread = false;

        public static void AtualizarProdutosCategoria()
        {
            Listas.ProdutosCategoria = ProdutosCategoriaController.GetAll();
        }
        public static void AtualizarCategorasNivel1()
        {
            Listas.CategoriasNivel1 = CategoriasNivel1Controller.GetAll();
        }
        public static void AtualizarCategorasNivel2()
        {
            Listas.CategoriasNivel2 = CategoriasNivel2Controller.GetAll();
        }
        public static void AtualizarCategorasNivel3()
        {
            Listas.CategoriasNivel3 = CategoriasNivel3Controller.GetAll();
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
