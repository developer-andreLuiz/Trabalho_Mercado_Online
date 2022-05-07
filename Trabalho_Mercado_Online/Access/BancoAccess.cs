using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using Trabalho_Mercado_Online.Access.Models;

namespace Trabalho_Mercado_Online.Access
{
    class BancoAccess
    {
        public static string conexaoLocal = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Banco_Dados\Soft.mdb;Jet OLEDB:Database Password ='Soft';";
        public static string conexaoRede = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = \\MAINSERVIDOR-PC\Arquivos Sistema Valendo\Banco_Dados\Soft.mdb;Jet OLEDB:Database Password = 'Soft';";
        public static OleDbConnection conexao = new OleDbConnection(conexaoRede);
        public class Categoria
        {
            static public List<Access_categoria_Model> GetAll()
            {
                List<Access_categoria_Model> listaFinal = new List<Access_categoria_Model>();

                string strgComando = "SELECT * FROM categoria order by id_categoria asc ;";
                OleDbCommand comando = new OleDbCommand(strgComando, conexao);

                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

                DataTable dtLista = new DataTable();

                dataAdapter.Fill(dtLista);


                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Access_categoria_Model access_Categoria_Model = new Access_categoria_Model()
                    {
                        nome = dataRow["nome"].ToString(),
                        id_categoria = int.Parse(dataRow["id_categoria"].ToString())
                    };
                    listaFinal.Add(access_Categoria_Model);
                }
                return listaFinal;
            }
            static public void Insert(Access_categoria_Model access_Categoria_ModelLocal)
            {
                string comandoString = "insert into categoria (nome) values (@nome);";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("nome", access_Categoria_ModelLocal.nome);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
            static public void Update(Access_categoria_Model access_Categoria_ModelLocal)
            {
                string comandoString = "update categoria set  nome = @nome where id_categoria = @id_categoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("nome", access_Categoria_ModelLocal.nome);
                comando.Parameters.AddWithValue("id_categoria", access_Categoria_ModelLocal.id_categoria);
                comando.ExecuteNonQuery();

            }
            static public void Delete(int idLocal)
            {
                string comandoString = "delete from categoria where id_categoria = @id_categoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("id_categoria", idLocal);
                comando.ExecuteNonQuery();
            }
        }
        public class Subcategoria
        {
            static public List<Access_subcategoria_Model> GetAll()
            {
                List<Access_subcategoria_Model> listaFinal = new List<Access_subcategoria_Model>();
                string strgComando = "SELECT * FROM subcategoria order by id_subcategoria asc ;";
                OleDbCommand comando = new OleDbCommand(strgComando, conexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);
                DataTable dtLista = new DataTable();
                dataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Access_subcategoria_Model access_SubCategoria_Model = new Access_subcategoria_Model()
                    {
                        nome = dataRow["nome"].ToString(),
                        id_categoria = int.Parse(dataRow["id_categoria"].ToString()),
                        id_subcategoria = int.Parse(dataRow["id_subcategoria"].ToString())
                    };
                    listaFinal.Add(access_SubCategoria_Model);
                }
                return listaFinal;
            }
            static public void Insert(Access_subcategoria_Model access_SubCategoria_ModelLocal)
            {
                string comandoString = "insert into subcategoria (nome, id_categoria) values (@nome, @id_categoria);";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("nome", access_SubCategoria_ModelLocal.nome);
                comando.Parameters.AddWithValue("id_categoria", access_SubCategoria_ModelLocal.id_categoria);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
            static public void Update(Access_subcategoria_Model accesaccess_SubCategoria_ModelLocal)
            {
                string comandoString = "update subcategoria set  nome = @nome, id_categoria = @id_categoria where id_subcategoria = @id_subcategoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("nome", accesaccess_SubCategoria_ModelLocal.nome);
                comando.Parameters.AddWithValue("id_categoria", accesaccess_SubCategoria_ModelLocal.id_categoria);
                comando.Parameters.AddWithValue("id_subcategoria", accesaccess_SubCategoria_ModelLocal.id_subcategoria);
                comando.ExecuteNonQuery();
            }
            static public void Delete(int idLocal)
            {
                string comandoString = "delete from subcategoria where id_subcategoria = @id_subcategoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("id_subcategoria", idLocal);
                comando.ExecuteNonQuery();
            }
            static public void DeleteCategoria(int idLocal)
            {
                string comandoString = "delete from subcategoria where id_categoria = @id_categoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("id_categoria", idLocal);
                comando.ExecuteNonQuery();
            }
        }
        public class Produtos
        {
            static public List<Access_Produtos_Model> GetAll()
            {
                List<Access_Produtos_Model> listaFinal = new List<Access_Produtos_Model>();
                string strgComando = "SELECT * FROM Produtos order by Codigo asc;";
                OleDbCommand comando = new OleDbCommand(strgComando, conexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);
                DataTable dtLista = new DataTable();
                dataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Access_Produtos_Model access_produtos_Model = new Access_Produtos_Model()
                    {
                        Referencia = dataRow["Referencia"].ToString(),
                        Descricao = dataRow["Descricao"].ToString().Trim(),
                        embalagem = dataRow["embalagem"].ToString(),
                        CustoUnitario = dataRow["CustoUnitario"].ToString(),
                        ValorVenda = dataRow["ValorVenda"].ToString(),
                        ValorPromocao = dataRow["ValorPromocao"].ToString(),
                        Codigo = int.Parse(dataRow["Codigo"].ToString()),
                        Numero = dataRow["Numero"].ToString(),
                        grama = dataRow["grama"].ToString(),
                        iguala = dataRow["iguala"].ToString(),
                        categoria = dataRow["categoria"].ToString(),
                        subcategoria = dataRow["subcategoria"].ToString(),
                        IgualaCx = dataRow["IgualaCx"].ToString(),
                        ChCaixa = dataRow["ChCaixa"].ToString(),
                        Quant_fardo = dataRow["Quant_fardo"].ToString(),
                    };
                    listaFinal.Add(access_produtos_Model);
                }
                return listaFinal;
            }
            static public void AtualizarProdutoCategoriaSubCategoriaLimpar(int idLocal)
            {
                string comandoString = "update Produtos set categoria = ' ', subcategoria = ' ' where categoria = @categoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("categoria", idLocal);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
            static public void AtualizarProdutoCategoriaSubCategoria(List<string> listLocal, string categoriaLocal, string subcategoriaLocal)
            {
                string codigoLocal = string.Empty;
                foreach (string a in listLocal)
                {
                    if (string.IsNullOrEmpty(codigoLocal))
                    {
                        codigoLocal = "'" + a + "'";
                    }
                    else
                    {
                        codigoLocal = codigoLocal + ", '" + a + "'";
                    }
                }
                string comandoString = "update Produtos set categoria = '" + categoriaLocal + "', subcategoria = '" + subcategoriaLocal + "' where Codigo in (" + codigoLocal + ");";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
            static public void AtualizarProdutoCategoriaSubCategoriaDesvincular(List<string> listLocal)
            {
                string codigoLocal = string.Empty;
                foreach (string a in listLocal)
                {
                    if (string.IsNullOrEmpty(codigoLocal))
                    {
                        codigoLocal = "'" + a + "'";
                    }
                    else
                    {
                        codigoLocal = codigoLocal + ", '" + a + "'";
                    }
                }
                string comandoString = "update Produtos set categoria = ' ', subcategoria = ' ' where Codigo in (" + codigoLocal + ");";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
            static public void AtualizarProdutoSubCategoria(int idLocal)
            {
                string comandoString = "update Produtos set subcategoria = ' ' where subcategoria = @subcategoria;";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                comando.Parameters.AddWithValue("subcategoria", idLocal);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
        }
        public class Itens_Vend
        {
            static public List<Access_itens_Vend_Model> GetAll()
            {
                List<Access_itens_Vend_Model> listaFinal = new List<Access_itens_Vend_Model>();
                string strgComando = "SELECT * FROM itens_Vend order by Codigo asc;";
                OleDbCommand comando = new OleDbCommand(strgComando, conexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);
                DataTable dtLista = new DataTable();
                dataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Access_itens_Vend_Model item = new Access_itens_Vend_Model()
                    {
                        Codigo = int.Parse(dataRow["Codigo"].ToString()),
                        Quant = int.Parse(dataRow["Quant"].ToString())
                    };
                    listaFinal.Add(item);
                }
                return listaFinal;
            }
            static public void Delete(List<string> listLocal)
            {
                string codigoLocal = string.Empty;
                foreach (string a in listLocal)
                {
                    if (string.IsNullOrEmpty(codigoLocal))
                    {
                        codigoLocal = "'" + a + "'";
                    }
                    else
                    {
                        codigoLocal = codigoLocal + ", '" + a + "'";
                    }
                }

                string comandoString = "delete from itens_Vend where Codigo in (" + codigoLocal + ");";
                OleDbCommand comando = new OleDbCommand(comandoString, conexao);
                //  comando.Parameters.AddWithValue("Codigo", codigoLocal);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
        }
        public class Prod_Codigo
        {
            static public List<Access_Prod_Codigo_Model> GetAll()
            {
                List<Access_Prod_Codigo_Model> listaFinal = new List<Access_Prod_Codigo_Model>();
                string strgComando = "SELECT * FROM Prod_Codigo order by Codigo asc;";
                OleDbCommand comando = new OleDbCommand(strgComando, conexao);
                if (conexao.State == ConnectionState.Closed)
                {
                    conexao.Open();
                }
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);
                DataTable dtLista = new DataTable();
                dataAdapter.Fill(dtLista);
                foreach (DataRow dataRow in dtLista.Rows)
                {
                    Access_Prod_Codigo_Model obj = new Access_Prod_Codigo_Model()
                    {
                        Controle = dataRow["Controle"].ToString(),
                        Codigo = dataRow["Codigo"].ToString(),
                        referencia = dataRow["referencia"].ToString(),
                        descriçao = dataRow["descriçao"].ToString()
                    };
                    listaFinal.Add(obj);
                }
                return listaFinal;
            }
        }
    }
}
