using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Item
    {
        private readonly static string _conn = @"Data Source=DESKTOP-HTEOBRF\SQLEXPRESS;
            Initial Catalog=TCCG5;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public int Id { get; set; }

        public string Nome { get; set; }

        public int Tipo_Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        public Item() { }

        public Item(int id, string nome, int tipo_id, string descricao, Decimal valor, DateTime data)
        {
            Id = id;
            Nome = nome;
            Tipo_Id = tipo_id;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }

        public static List<Item> GetItem()
        {
            var listaItem = new List<Item>();
            var sql = "SELECT * FROM Item";
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    listaItem.Add(new Item(Convert.ToInt32(dr["id"]),
                                        Convert.ToString(dr["nome"]),
                                       Convert.ToInt32(dr["tipo_id"]),
                                        Convert.ToString(dr["descricao"]),
                                        Convert.ToDecimal(dr["valor"]),
                                        Convert.ToDateTime(dr["data"])
                                       ));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return listaItem;

        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO Item (nome,tipo_id,descricao,valor,data)" +
                    " VALUES(@nome,@tipo_id, @descricao, @valor,  @data)";
            }
            else
            {
                sql = "UPDATE Item SET nome=@nome,tipo_id=@tipo_id,descricao=@descricao,valor=@valor ,data = @data WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@tipo_id", Tipo_Id);
                        cmd.Parameters.AddWithValue("@descricao", Descricao);
                        cmd.Parameters.AddWithValue("@valor", Valor);
                        cmd.Parameters.AddWithValue("@data", Data);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }

        }

        public void Excluir()
        {
            var sql = "DELETE FROM Item WHERE id=" + Id;
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }

        public void GetItem(int id)
        {
            var sql = "SELECT * FROM Item WHERE id=" + id;
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                if (dr.Read())
                                {
                                    Id = id;
                                    Nome = Convert.ToString(dr["nome"]);
                                    Tipo_Id = Convert.ToInt32(dr["tipo_id"]);
                                    Descricao = Convert.ToString(dr["descricao"]);
                                    Valor = Convert.ToDecimal(dr["valor"]);
                                    Data = Convert.ToDateTime(dr["data"]);

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Falha: " + ex.Message);
            }
        }
    }
}