using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class ProdutosCodigoBarraController
    {
        public static List<ProdutosCodigoBarra> GetAll()
        {
            List<ProdutosCodigoBarra> Lista = ProdutosCodigoBarraDAO.GetAll();
            return Lista;
        }
        public static ProdutosCodigoBarra Gravar(ProdutosCodigoBarra obj)
        {
            if (obj.Id > 0)
            {
                obj = ProdutosCodigoBarraDAO.Update(obj);
            }
            else
            {
                obj = ProdutosCodigoBarraDAO.Insert(obj);
            }
            return obj;
        }
        public static bool Deletar(ProdutosCodigoBarra obj)
        {
            bool r = true;

            try
            {
                ProdutosCodigoBarraDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
