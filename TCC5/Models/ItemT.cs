using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class ItemT
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

        public ItemT() { }

        public ItemT(int id, string nome)
        {
            Id = id;

            Nome = nome;
        }

        public static List<ItemT> GetItemT()
        {
            var listaItemT = new List<ItemT>();
            var sql = "SELECT * FROM tipo_item";
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
                                    listaItemT.Add(new ItemT(Convert.ToInt32(dr["id"]),
                                        Convert.ToString(dr["nome"])
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
            return listaItemT;
        }

        public void Salvar()
        {
            var iSQL = "";
            if (Id == 0)
            {
                iSQL = "INSERT INTO tipo_item (nome) VALUES(@nome)";
            }
            else
            {
                iSQL = "UPDATE tipo_item SET nome=@nome WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(iSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@nome", Nome);
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
            var iSQL = "DELETE FROM tipo_item WHERE id=" + Id;
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(iSQL, cn))
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

        public void GetItemT(int id)
        {
            var sql = "SELECT * FROM tipo_item WHERE id=" + id;
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