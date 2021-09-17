using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class ProdutosCategoriaController
    {
        public static List<ProdutosCategoria> GetAll()
        {
            List<ProdutosCategoria> Lista = ProdutosCategoriaDAO.GetAll();
            return Lista;
        }
        public static ProdutosCategoria Gravar(ProdutosCategoria obj)
        {
            if (obj.Id > 0)
            {
                ProdutosCategoriaDAO.Update(obj);
            }
            else
            {
                ProdutosCategoriaDAO.Insert(obj);
            }
            return obj;
        }
        public static bool Deletar(ProdutosCategoria obj)
        {
            bool r = false;
            try
            {
                ProdutosCategoriaDAO.Delete(obj);
            }
            catch { r = false; }
            return r;
        }
    }
}
