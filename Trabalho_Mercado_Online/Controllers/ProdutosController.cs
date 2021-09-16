using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Helpers;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class ProdutosController
    {
        public static List<Produtos> GetAll()
        {
            List<Produtos> Lista = ProdutosDAO.GetAll();
            return Lista;
        }
        public static Produtos Gravar(Produtos obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://aplicativo.blob.core.windows.net/produtos/" + obj.Id + ".jpg";
                obj = ProdutosDAO.Update(obj);
            }
            else
            {
                obj = ProdutosDAO.Insert(obj);
                obj.Img = @"https://aplicativo.blob.core.windows.net/produtos/"+obj.Id+".jpg";
                obj = ProdutosDAO.Update(obj);
            }
            return obj;
        }
        public static bool Deletar(Produtos obj)
        {
            bool r = true;

            try
            {
                ProdutosDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
