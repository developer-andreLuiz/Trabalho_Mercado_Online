using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Dao;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    public class LojaPrateleiraController
    {
        public static List<LojaPrateleira> GetAll()
        {
            List<LojaPrateleira> Lista = LojaPrateleiraDAO.GetAll();
            return Lista;
        }
        public static LojaPrateleira Gravar(LojaPrateleira obj)
        {
            if (obj.Id > 0)
            {
                obj = LojaPrateleiraDAO.Update(obj);
            }
            else
            {
                obj = LojaPrateleiraDAO.Insert(obj);
            }
            return obj;
        }
        public static bool Deletar(LojaPrateleira obj)
        {
            bool r = true;

            try
            {
                LojaPrateleiraDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
