using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class ProdutoCategoriaDAO
    {
        public static ProdutoCategorium Get(int id)
        {
            ProdutoCategorium obj = new ProdutoCategorium();
            using (var banco = new DBContextDAO())
            {
                obj = banco.ProdutoCategoria.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<ProdutoCategorium> GetAll()
        {
            List<ProdutoCategorium> Lista = new List<ProdutoCategorium>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.ProdutoCategoria.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
           
            return Lista;
        }
        public static bool Insert(ProdutoCategorium obj)
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
        public static bool Update(ProdutoCategorium obj)
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
        public static bool Delete(ProdutoCategorium obj)
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
