using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Dao;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    public class LojaEstanteController
    {
        public static List<LojaEstante> GetAll()
        {
            List<LojaEstante> Lista = LojaEstanteDAO.GetAll();
            return Lista;
        }
        public static LojaEstante Inserir(LojaEstante obj)
        {
            obj = LojaEstanteDAO.Insert(obj);
            return obj;
        }
        public static LojaEstante Atualizar(LojaEstante obj)
        {
            obj = LojaEstanteDAO.Update(obj);
            return obj;
        }
        public static bool Deletar(LojaEstante obj)
        {
            bool r = true;

            try
            {
                LojaEstanteDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
