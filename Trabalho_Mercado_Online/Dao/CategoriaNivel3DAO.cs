using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class CategoriaNivel3DAO
    {
        public static CategoriaNivel3 Get(int id)
        {
            CategoriaNivel3 obj = new CategoriaNivel3();
            using (var banco = new DBContextDAO())
            {
                obj = banco.CategoriaNivel3s.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<CategoriaNivel3> GetAll()
        {
            List<CategoriaNivel3> Lista = new List<CategoriaNivel3>();
            try 
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.CategoriaNivel3s.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
               
            } catch { }
            return Lista;
        }
        public static CategoriaNivel3 Insert(CategoriaNivel3 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static CategoriaNivel3 Update(CategoriaNivel3 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(CategoriaNivel3 obj)
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
