using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class EncarteItemDAO
    {
        public static EncarteItem Get(int id)
        {
            EncarteItem obj = new EncarteItem();
            using (var banco = new DBContextDAO())
            {
                obj = banco.EncarteItems.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<EncarteItem> GetAll()
        {
            List<EncarteItem> Lista = new List<EncarteItem>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.EncarteItems.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }

            return Lista;
        }
        public static EncarteItem Insert(EncarteItem obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static EncarteItem Update(EncarteItem obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(EncarteItem obj)
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
