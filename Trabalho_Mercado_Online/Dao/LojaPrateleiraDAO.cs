using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Dao
{
    public class LojaPrateleiraDAO
    {
        public static LojaPrateleira Get(int id)
        {
            LojaPrateleira obj = new LojaPrateleira();
            using (var banco = new DBContextDAO())
            {
                obj = banco.LojaPrateleiras.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<LojaPrateleira> GetAll()
        {
            List<LojaPrateleira> Lista = new List<LojaPrateleira>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.LojaPrateleiras.AsNoTracking().AsQueryable().OrderBy(x => x.Id);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static LojaPrateleira Insert(LojaPrateleira obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static LojaPrateleira Update(LojaPrateleira obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(LojaPrateleira obj)
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
