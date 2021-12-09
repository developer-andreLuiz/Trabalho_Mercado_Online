using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class EncarteController
    {
        public static List<Encarte> GetAll()
        {
            List<Encarte> Lista = EncarteDAO.GetAll();
            return Lista;
        }
        public static Encarte Gravar(Encarte obj)
        {
            if (obj.Id > 0)
            {
                obj=EncarteDAO.Update(obj);
            }
            else
            {
                obj=EncarteDAO.Insert(obj);
            }
            return obj;
        }
        public static bool Deletar(Encarte obj)
        {
            bool r = true;

            try
            {
                EncarteDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
