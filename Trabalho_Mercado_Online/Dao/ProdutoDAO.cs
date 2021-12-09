using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho_Mercado_Online.DAO
{
    class ProdutoDAO
    {
        public static Produto Get(int id)
        {
            Produto obj = new Produto();
            using (var banco = new DBContextDAO())
            {
                obj = banco.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<Produto> GetAll()
        {
            List<Produto> Lista = new List<Produto>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.Produtos.AsNoTracking().AsQueryable().OrderBy(x => x.Descricao);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            
            return Lista;
        }
        public static Produto Insert(Produto obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static Produto Update(Produto obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(Produto obj)
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
