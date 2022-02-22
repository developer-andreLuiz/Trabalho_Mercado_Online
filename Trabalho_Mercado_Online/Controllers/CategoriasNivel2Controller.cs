using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class CategoriasNivel2Controller
    {
        public static List<CategoriasNivel2> GetAll()
        {
            List<CategoriasNivel2> Lista = CategoriasNivel2DAO.GetAll();
            return Lista;
        }
        public static CategoriasNivel2 Gravar(CategoriasNivel2 obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://mercadoonline.blob.core.windows.net/categoria-nivel-2/" + obj.Id + ".jpg";
                obj = CategoriasNivel2DAO.Update(obj);
            }
            else
            {
                obj = CategoriasNivel2DAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(CategoriasNivel2 obj)
        {
            bool r = true;

            try
            {
                CategoriasNivel2DAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
