using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Controllers;


namespace Trabalho_Mercado_Online.Helpers
{
    class Global
    {
        public static ListasBanco Listas = new ListasBanco();
        public static List<Imagem> ListaImagem = new List<Imagem>();
        public static String CaminhoPastaImagem { get; set; }
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
    }
}
