using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class ProdutoCodigoBarraController
    {
        public static List<ProdutoCodigoBarra> GetAll()
        {
            List<ProdutoCodigoBarra> Lista = ProdutoCodigoBarraDAO.GetAll();
            return Lista;
        }
        public static ProdutoCodigoBarra Gravar(ProdutoCodigoBarra obj)
        {
            if (obj.Id > 0)
            {
                obj = ProdutoCodigoBarraDAO.Update(obj);
            }
            else
            {
                obj = ProdutoCodigoBarraDAO.Insert(obj);
            }
            return obj;
        }
        public static bool Deletar(ProdutoCodigoBarra obj)
        {
            bool r = true;

            try
            {
                ProdutoCodigoBarraDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
