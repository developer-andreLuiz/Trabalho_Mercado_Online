using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class EncarteDAO
    {
        public static Encarte Get(int id)
        {
            Encarte obj = new Encarte();
            using (var banco = new DBContextDAO())
            {
                obj = banco.Encartes.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<Encarte> GetAll()
        {
            List<Encarte> Lista = new List<Encarte>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.Encartes.AsNoTracking().AsQueryable().OrderByDescending(x => x.Id); ;
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }

            return Lista;
        }
        public static Encarte Insert(Encarte obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static Encarte Update(Encarte obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(Encarte obj)
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
