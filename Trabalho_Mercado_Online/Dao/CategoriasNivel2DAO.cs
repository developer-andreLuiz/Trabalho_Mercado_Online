using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.DAO
{
    class CategoriasNivel2DAO
    {
        public static CategoriasNivel2 Get(int id)
        {
            CategoriasNivel2 obj = new CategoriasNivel2();
            using (var banco = new DBContextDAO())
            {
                obj = banco.CategoriasNivel2s.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            return obj;
        }
        public static List<CategoriasNivel2> GetAll()
        {
            List<CategoriasNivel2> Lista = new List<CategoriasNivel2>();
            try
            {
                using (var banco = new DBContextDAO())
                {
                    var itens = banco.CategoriasNivel2s.AsNoTracking().AsQueryable().OrderBy(x => x.Nome);
                    Lista.AddRange(itens.ToList());
                }
            }
            catch { }
            return Lista;
        }
        public static CategoriasNivel2 Insert(CategoriasNivel2 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Add(obj);
                banco.SaveChanges();
            }
            return obj;
            
        }
        public static CategoriasNivel2 Update(CategoriasNivel2 obj)
        {
            using (var banco = new DBContextDAO())
            {
                banco.Update(obj);
                banco.SaveChanges();
            }
            return obj;
        }
        public static bool Delete(CategoriasNivel2 obj)
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
