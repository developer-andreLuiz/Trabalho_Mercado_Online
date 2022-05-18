using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Dao;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    public class FuncionarioCargoController
    {
        public static List<FuncionarioCargo> GetAll()
        {
            List<FuncionarioCargo> Lista = FuncionarioCargoDAO.GetAll();
            return Lista;
        }
        public static FuncionarioCargo Inserir(FuncionarioCargo obj)
        {
            obj = FuncionarioCargoDAO.Insert(obj);
            return obj;
        }
        public static FuncionarioCargo Atualizar(FuncionarioCargo obj)
        {
            obj = FuncionarioCargoDAO.Update(obj);
            return obj;
        }
        public static bool Deletar(FuncionarioCargo obj)
        {
            bool r = true;
            try
            {
                FuncionarioCargoDAO.Delete(obj);
            }
            catch { r = false; }
            return r;
        }
    }
}
