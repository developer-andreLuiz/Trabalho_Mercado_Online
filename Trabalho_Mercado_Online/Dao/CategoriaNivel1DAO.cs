using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class CategoriaNivel1DAO
    {
        public static CategoriaNivel1 Get(int id)
        {
            CategoriaNivel1 obj = new CategoriaNivel1();
            using (var banco = new DBContextDAO())
            {
                obj = banco.CategoriaNivel1s.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<CategoriaNivel1> GetAll()
        {
            List<CategoriaNivel1> Lista = new List<CategoriaNivel1>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.CategoriaNivel1s.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static CategoriaNivel1 Insert(CategoriaNivel1 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static CategoriaNivel1 Update(CategoriaNivel1 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(CategoriaNivel1 obj)
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
