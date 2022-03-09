using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class CategoriaNivel2Controller
    {
        public static List<CategoriaNivel2> GetAll()
        {
            List<CategoriaNivel2> Lista = CategoriaNivel2DAO.GetAll();
            return Lista;
        }
        public static CategoriaNivel2 Gravar(CategoriaNivel2 obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://mercadoonline.blob.core.windows.net/categoria-nivel-2/" + obj.Id + ".jpg";
                obj = CategoriaNivel2DAO.Update(obj);
            }
            else
            {
                obj = CategoriaNivel2DAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(CategoriaNivel2 obj)
        {
            bool r = true;

            try
            {
                CategoriaNivel2DAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
