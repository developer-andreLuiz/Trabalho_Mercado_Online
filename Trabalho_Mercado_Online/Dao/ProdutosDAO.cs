using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho_Mercado_Online.DAO
{
    class ProdutosDAO
    {
        public static Produtos Get(int id)
        {
            Produtos obj = new Produtos();
            using (var banco = new DBContextDAO())
            {
                obj = banco.Produtos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<Produtos> GetAll()
        {
            List<Produtos> Lista = new List<Produtos>();
            using (var banco = new DBContextDAO())
            {
                var itens = banco.Produtos.AsNoTracking().AsQueryable().OrderBy(x => x.Descricao);
                Lista.AddRange(itens.ToList());
            }
            return Lista;
        }
        public static Produtos Insert(Produtos obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static Produtos Update(Produtos obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(Produtos obj)
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
