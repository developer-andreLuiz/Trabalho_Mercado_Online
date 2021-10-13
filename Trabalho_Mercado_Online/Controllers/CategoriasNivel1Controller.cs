using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class CategoriasNivel1Controller
    {
        public static List<CategoriasNivel1> GetAll()
        {
            List<CategoriasNivel1> Lista = CategoriasNivel1DAO.GetAll();
            return Lista;
        }
        public static CategoriasNivel1 Gravar(CategoriasNivel1 obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://aplicativo.blob.core.windows.net/categoriasnivel1/" + obj.Id + ".jpg";
                obj = CategoriasNivel1DAO.Update(obj);
            }
            else
            {
                obj = CategoriasNivel1DAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(CategoriasNivel1 obj)
        {
            bool r = true;

            try
            {
                CategoriasNivel1DAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
