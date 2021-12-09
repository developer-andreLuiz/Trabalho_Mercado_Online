using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class EncarteItemController
    {
        public static List<EncarteItem> GetAll()
        {
            List<EncarteItem> Lista = EncarteItemDAO.GetAll();
            return Lista;
        }
        public static EncarteItem Gravar(EncarteItem obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://aplicativo.blob.core.windows.net/encarte/" + obj.Id + ".jpg";
                obj = EncarteItemDAO.Update(obj);
            }
            else
            {
                obj.Img = "Url";
                obj = EncarteItemDAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(EncarteItem obj)
        {
            bool r = true;

            try
            {
                EncarteItemDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
