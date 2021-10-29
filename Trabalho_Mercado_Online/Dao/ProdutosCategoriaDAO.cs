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
        public static ProdutosCategoria Get(int id)
        {
            ProdutosCategoria obj = new ProdutosCategoria();
            using (var banco = new DBContextDAO())
            {
                obj = banco.ProdutosCategoria.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<ProdutosCategoria> GetAll()
        {
            List<ProdutosCategoria> Lista = new List<ProdutosCategoria>();
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
        public static bool Insert(ProdutosCategoria obj)
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
        public static bool Update(ProdutosCategoria obj)
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
        public static bool Delete(ProdutosCategoria obj)
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
