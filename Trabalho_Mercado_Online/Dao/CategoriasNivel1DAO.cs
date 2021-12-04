using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class CategoriasNivel1DAO
    {
        public static CategoriasNivel1 Get(int id)
        {
            CategoriasNivel1 obj = new CategoriasNivel1();
            using (var banco = new DBContextDAO())
            {
                obj = banco.CategoriasNivel1s.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<CategoriasNivel1> GetAll()
        {
            List<CategoriasNivel1> Lista = new List<CategoriasNivel1>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.CategoriasNivel1s.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static CategoriasNivel1 Insert(CategoriasNivel1 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static CategoriasNivel1 Update(CategoriasNivel1 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(CategoriasNivel1 obj)
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
