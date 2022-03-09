using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class CategoriaNivel3Controller
    {
        public static List<CategoriaNivel3> GetAll()
        {
            List<CategoriaNivel3> Lista = CategoriaNivel3DAO.GetAll();
            return Lista;
        }
        public static CategoriaNivel3 Gravar(CategoriaNivel3 obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://mercadoonline.blob.core.windows.net/categoria-nivel-3/" + obj.Id + ".jpg";
                obj = CategoriaNivel3DAO.Update(obj);
            }
            else
            {
                obj = CategoriaNivel3DAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(CategoriaNivel3 obj)
        {
            bool r = true;

            try
            {
                CategoriaNivel3DAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
