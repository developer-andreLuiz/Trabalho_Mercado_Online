using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class ProdutosCategoriaDAO
    {
        public static ProdutosCategorium Get(int id)
        {
            ProdutosCategorium obj = new ProdutosCategorium();
            using (var banco = new DBContextDAO())
            {
                obj = banco.ProdutosCategoria.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<ProdutosCategorium> GetAll()
        {
            List<ProdutosCategorium> Lista = new List<ProdutosCategorium>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.ProdutosCategoria.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
           
            return Lista;
        }
        public static bool Insert(ProdutosCategorium obj)
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
        public static bool Update(ProdutosCategorium obj)
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
        public static bool Delete(ProdutosCategorium obj)
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
