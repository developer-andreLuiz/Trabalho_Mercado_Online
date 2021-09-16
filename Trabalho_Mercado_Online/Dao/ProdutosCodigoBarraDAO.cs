using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class ProdutosCodigoBarraDAO
    {
        public static ProdutosCodigoBarra Get(int id)
        {
            ProdutosCodigoBarra obj = new ProdutosCodigoBarra();
            using (var banco = new DBContextDAO())
            {
                obj = banco.ProdutosCodigoBarras.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<ProdutosCodigoBarra> GetAll()
        {
            List<ProdutosCodigoBarra> Lista = new List<ProdutosCodigoBarra>();
            using (var banco = new DBContextDAO())
            {
                var itens = banco.ProdutosCodigoBarras.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                Lista.AddRange(itens.ToList());
            }
            return Lista;
        }
        public static bool Insert(ProdutosCodigoBarra obj)
        {
            int retorno = 0;
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                retorno = banco.SaveChanges();
            }
            if (retorno == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Update(ProdutosCodigoBarra obj)
        {
            int retorno = 0;
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                retorno = banco.SaveChanges();
            }
            if (retorno == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool Delete(ProdutosCodigoBarra obj)
        {
            int retorno = 0;
            using (var banco = new DBContextDAO())
            {
                banco.Remove(obj);
                retorno = banco.SaveChanges();
            }
            if (retorno == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
