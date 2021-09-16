using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class CategoriasNivel3DAO
    {
        public static CategoriasNivel3 Get(int id)
        {
            CategoriasNivel3 obj = new CategoriasNivel3();
            using (var banco = new DBContextDAO())
            {
                obj = banco.CategoriasNivel3s.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<CategoriasNivel3> GetAll()
        {
            List<CategoriasNivel3> Lista = new List<CategoriasNivel3>();
            using (var banco = new DBContextDAO())
            {
                var itens = banco.CategoriasNivel3s.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                Lista.AddRange(itens.ToList());
            }
            return Lista;
        }
        public static bool Insert(CategoriasNivel3 obj)
        {
            int retorno = 0;
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
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
        public static bool Update(CategoriasNivel3 obj)
        {
            int retorno = 0;
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
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
        public static bool Delete(CategoriasNivel3 obj)
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
