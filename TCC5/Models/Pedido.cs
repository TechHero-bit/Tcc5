using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Pedido
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

        public int Comanda_id { get; set; }

        public DateTime Data { get; set; }

        public Pedido() { }

        public Pedido(int id, int comanda_id, DateTime data)
        {
            Id = id;
            Comanda_id = comanda_id;
            Data = data;
        }

        public static List<Pedido> GetPedido()
        {
            var listaPedido = new List<Pedido>();
            var sql = "SELECT * FROM pedido";
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
                                    listaPedido.Add(new Pedido(Convert.ToInt32(dr["id"]),
                                        Convert.ToInt32(dr["comanda_id"]),
                                        Convert.ToDateTime(dr["datetime"])
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
            return listaPedido;

        }

        public void Salvar()
        {
            var iSQL = "";
            if (Id == 0)
            {
                iSQL = "INSERT INTO pedido (Comanda_id,datetime) VALUES(@Comanda_id, @datetime)";
            }
            else
            {
                iSQL = "UPDATE pedido SET Comanda_id=@Comanda_id,datetime = @datetime WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(iSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@Comanda_id", Comanda_id);
                        cmd.Parameters.AddWithValue("@datetime", Data);

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
            var iSQL = "DELETE FROM pedido WHERE id=" + Id;
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

        public void GetPedido(int id)
        {
            var sql = "SELECT * FROM pedido WHERE id=" + id;
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
                                    Comanda_id = Convert.ToInt32(dr["comanda_id"]);
                                    Data = Convert.ToDateTime(dr["datetime"]);

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