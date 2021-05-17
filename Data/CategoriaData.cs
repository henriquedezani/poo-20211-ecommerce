using Ecommerce2021a.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Data
{
    public class CategoriaData : Data
    {
        public List<Categoria> Read()
        {
            List<Categoria> lista = new List<Categoria>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = "Select * From Categoria";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.IdCategoria = (int)reader["IdCategoria"];
                categoria.Nome = (string)reader["Nome"];

                lista.Add(categoria);
            }

            return lista;
        }
    }
}
