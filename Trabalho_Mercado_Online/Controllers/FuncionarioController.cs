using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_Mercado_Online.Dao;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    public class FuncionarioController
    {
        public static List<Funcionario> GetAll()
        {
            List<Funcionario> Lista = FuncionarioDAO.GetAll();
            return Lista;
        }
        public static Funcionario Inserir(Funcionario obj)
        {
            obj = FuncionarioDAO.Insert(obj);
            return obj;
        }
        public static Funcionario Atualizar(Funcionario obj)
        {
            obj = FuncionarioDAO.Update(obj);
            return obj;
        }
        public static bool Deletar(Funcionario obj)
        {
            bool r = true;
            try
            {
                FuncionarioDAO.Delete(obj);
            }
            catch { r = false; }
            return r;
        }
    }
}
