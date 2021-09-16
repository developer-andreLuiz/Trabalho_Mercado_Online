﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_Mercado_Online.DAO;
using Trabalho_Mercado_Online.Models;

namespace Trabalho_Mercado_Online.Controllers
{
    class CategoriasNivel3Controller
    {
        public static List<CategoriasNivel3> GetAll()
        {
            List<CategoriasNivel3> Lista = CategoriasNivel3DAO.GetAll();
            return Lista;
        }
        public static CategoriasNivel3 Gravar(CategoriasNivel3 obj)
        {
            if (obj.Id > 0)
            {
                CategoriasNivel3DAO.Update(obj);
            }
            else
            {
                CategoriasNivel3DAO.Insert(obj);
            }
            return obj;




        }
        public static bool Deletar(CategoriasNivel3 obj)
        {
            bool r = true;

            try
            {
                CategoriasNivel3DAO.Delete(obj);
            }
            catch { r = false; }

            return r;
        }
    }
}
