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
        public static List<ProdutosCategorium> GetAll()
        {
            List<ProdutosCategorium> Lista = ProdutosCategoriaDAO.GetAll();
            return Lista;
        }
        public static ProdutosCategorium Gravar(ProdutosCategorium obj)
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
        public static bool Deletar(ProdutosCategorium obj)
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
