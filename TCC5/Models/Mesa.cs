using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Mesa
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
        public int Numero { get; set; }

        public int Setor { get; set; }

        public bool Status { get; set; }

        public DateTime Data { get; set; }

        public Mesa() { }

        public Mesa(int id, int numero, int setor, bool status, DateTime data)
        {
            Id = id;
            Numero = numero;
            Setor = setor;
            Status = status;
            Data = data;
        }

        public static List<Mesa> GetMesas()
        {
            var listaMesas = new List<Mesa>();
            var sql = "SELECT * FROM mesa";
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
                                    listaMesas.Add(new Mesa(Convert.ToInt32(dr["id"]),
                                       Convert.ToInt32(dr["numero"]),
                                        Convert.ToInt32(dr["setor"]),
                                        Convert.ToBoolean(dr["status_mesa"]),
                                        Convert.ToDateTime(dr["data"])));
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
            return listaMesas;

        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO mesa (id,numero,setor,status,data) VALUES(@id,@numero, @setor, @status_mesa,  @data)";
            }
            else
            {
                sql = "UPDATE mesa SET id=@id,numero=@numero ,setor=@setor,status_mesa=@status_mesa ,data=@data WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@numero", Numero);
                        cmd.Parameters.AddWithValue("@setor", Setor);
                        cmd.Parameters.AddWithValue("@status_mesa", Status);
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
            var iSQL = "DELETE FROM mesa WHERE id=" + Id;
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

        public void GetMesas(int id)
        {
            var sql = "SELECT * FROM mesa WHERE id=" + id;
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
                                    Numero = Convert.ToInt32(dr["numero"]);
                                    Setor = Convert.ToInt32(dr["setor"]);
                                    Status = Convert.ToBoolean(dr["status_mesa"]);
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