using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class CategoriaNivel2DAO
    {
        public static CategoriaNivel2 Get(int id)
        {
            CategoriaNivel2 obj = new CategoriaNivel2();
            using (var banco = new DBContextDAO())
            {
                obj = banco.CategoriaNivel2s.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<CategoriaNivel2> GetAll()
        {
            List<CategoriaNivel2> Lista = new List<CategoriaNivel2>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.CategoriaNivel2s.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static CategoriaNivel2 Insert(CategoriaNivel2 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
            
        }
        public static CategoriaNivel2 Update(CategoriaNivel2 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(CategoriaNivel2 obj)
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
