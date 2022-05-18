using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Dao
{
    public class LojaEstanteDAO
    {
        public static LojaEstante Get(int id)
        {
            LojaEstante obj = new LojaEstante();
            using (var banco = new DBContextDAO())
            {
                obj = banco.LojaEstantes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<LojaEstante> GetAll()
        {
            List<LojaEstante> Lista = new List<LojaEstante>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.LojaEstantes.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static LojaEstante Insert(LojaEstante obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static LojaEstante Update(LojaEstante obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(LojaEstante obj)
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
