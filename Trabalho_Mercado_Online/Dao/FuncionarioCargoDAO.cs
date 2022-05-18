using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Dao
{
    public class FuncionarioCargoDAO
    {
        public static FuncionarioCargo Get(int id)
        {
            FuncionarioCargo obj = new FuncionarioCargo();
            using (var banco = new DBContextDAO())
            {
                obj = banco.FuncionarioCargos.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<FuncionarioCargo> GetAll()
        {
            List<FuncionarioCargo> Lista = new List<FuncionarioCargo>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.FuncionarioCargos.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static FuncionarioCargo Insert(FuncionarioCargo obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static FuncionarioCargo Update(FuncionarioCargo obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(FuncionarioCargo obj)
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
