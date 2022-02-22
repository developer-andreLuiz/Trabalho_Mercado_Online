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
    class ProdutoController
    {
        public static List<Produto> GetAll()
        {
            List<Produto> Lista = ProdutoDAO.GetAll();
            return Lista;
        }
        public static Produto Gravar(Produto obj)
        {
            if (obj.Id > 0)
            {
                obj.Img = @"https://mercadoonline.blob.core.windows.net/produto/" + obj.Id + ".jpg";
                obj = ProdutoDAO.Update(obj);

                if (obj.IgualaProduto>0)
                {
                    List<Produto> ListaIguala = ProdutoDAO.GetAll().FindAll(x=>x.IgualaProduto==obj.IgualaProduto);
                    foreach (var item in ListaIguala)
                    {
                        item.ValorVenda = obj.ValorVenda;
                        item.ValorPromocao = obj.ValorPromocao;
                        item.Peso = obj.Peso;
                        item.ItensCaixa = obj.ItensCaixa;
                        item.Volume = obj.Volume;
                        item.Gramatura = obj.Gramatura;
                        item.Embalagem = obj.Embalagem;

                        ProdutoDAO.Update(item);
                    }
                }
            }
            else
            {
                obj = ProdutoDAO.Insert(obj);
                obj = Gravar(obj);
            }
            return obj;
        }
        public static bool Deletar(Produto obj)
        {
            bool r = true;

            try
            {
                ProdutoDAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
