using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class ProdutoCodigoBarraDAO
    {
        public static ProdutoCodigoBarra Get(int id)
        {
            ProdutoCodigoBarra obj = new ProdutoCodigoBarra();
            using (var banco = new DBContextDAO())
            {
                obj = banco.ProdutoCodigoBarras.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<ProdutoCodigoBarra> GetAll()
        {
            List<ProdutoCodigoBarra> Lista = new List<ProdutoCodigoBarra>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.ProdutoCodigoBarras.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            
            return Lista;
        }
        public static ProdutoCodigoBarra Insert(ProdutoCodigoBarra obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
                return obj;
            }
        }
        public static ProdutoCodigoBarra Update(ProdutoCodigoBarra obj)
        {
          
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
                return obj;
            }
           
        }
        public static bool Delete(ProdutoCodigoBarra obj)
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
