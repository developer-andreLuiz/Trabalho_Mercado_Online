using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class CategoriaNivel1Controller
    {
        public static List<CategoriaNivel1> GetAll()
        {
            List<CategoriaNivel1> Lista = CategoriaNivel1DAO.GetAll();
            return Lista;
        }
        public static CategoriaNivel1 Gravar(CategoriaNivel1 obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://mercadoonline.blob.core.windows.net/categoria-nivel-1/" + obj.Id + ".jpg";
                obj = CategoriaNivel1DAO.Update(obj);
            }
            else
            {
                obj = CategoriaNivel1DAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(CategoriaNivel1 obj)
        {
            bool r = true;

            try
            {
                CategoriaNivel1DAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
