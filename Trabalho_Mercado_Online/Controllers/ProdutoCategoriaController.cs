using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class ProdutoCategoriaController
    {
        public static List<ProdutoCategorium> GetAll()
        {
            List<ProdutoCategorium> Lista = ProdutoCategoriaDAO.GetAll();
            return Lista;
        }
        public static ProdutoCategorium Gravar(ProdutoCategorium obj)
        {
            if (obj.Id > 0)
            {
                ProdutoCategoriaDAO.Update(obj);
            }
            else
            {
                ProdutoCategoriaDAO.Insert(obj);
            }
            return obj;
        }
        public static bool Deletar(ProdutoCategorium obj)
        {
            bool r = false;
            try
            {
                ProdutoCategoriaDAO.Delete(obj);
            }
            catch { r = false; }
            return r;
        }
    }
}
