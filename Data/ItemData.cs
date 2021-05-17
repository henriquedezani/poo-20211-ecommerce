using Ecommerce2021a.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce2021a.Data
{
    public class ItemData : Data
    {
        public List<Item> Read(int id)
        {
            List<Item> lista = new List<Item>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = base.connectionDB;
            cmd.CommandText = @"Select ip.*, p.Nome From ItemPedido ip inner Join
                                Prodduto p on p.IdProduto = ip.IdProduto
                                Where ip.IdPedido = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read()) //Percorre a tablea até o EOF
            {
                Item item = new Item();
                item.IdPedido = (int)reader["IdPedido"];

                item.Produto = new Produto
                {
                    IdProduto = (int)reader["IdProduto"],
                    Nome = (string)reader["Nome"]
                };

                item.Quantidade = (int)reader["Quantidade"];
                item.Valor = (decimal)reader["Preco"];

                lista.Add(item);
            }

            return lista;
        }
    }
}