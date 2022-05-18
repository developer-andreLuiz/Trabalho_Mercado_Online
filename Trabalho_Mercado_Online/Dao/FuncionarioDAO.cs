using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Dao
{
    public class FuncionarioDAO
    {
        public static Funcionario Get(int id)
        {
            Funcionario obj = new Funcionario();
            using (var banco = new DBContextDAO())
            {
                obj = banco.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<Funcionario> GetAll()
        {
            List<Funcionario> Lista = new List<Funcionario>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.Funcionarios.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static Funcionario Insert(Funcionario obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static Funcionario Update(Funcionario obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(Funcionario obj)
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
