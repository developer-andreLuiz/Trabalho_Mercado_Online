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
        public static List<Produto> GetAll()
        {
            List<Produto> Lista = ProdutosDAO.GetAll();
            return Lista;
        }
        public static Produto Gravar(Produto obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://aplicativo.blob.core.windows.net/produtos/" + obj.Id + ".jpg";
                obj = ProdutosDAO.Update(obj);

                if (obj.IgualaProduto>0)
                {
                    List<Produto> ListaIguala = ProdutosDAO.GetAll().FindAll(x=>x.IgualaProduto==obj.IgualaProduto);
                    foreach (var item in ListaIguala)
                    {
                        item.ValorVenda = obj.ValorVenda;
                        item.ValorPromocao = obj.ValorPromocao;
                        item.Peso = obj.Peso;
                        item.ItensCaixa = obj.ItensCaixa;
                        item.Volume = obj.Volume;
                        item.Gramatura = obj.Gramatura;
                        item.Embalagem = obj.Embalagem;

                        ProdutosDAO.Update(item);
                    }
                }
            }
            else
            {
                obj = ProdutosDAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(Produto obj)
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
