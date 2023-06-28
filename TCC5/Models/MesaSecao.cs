using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class MesaSecao
    {
        private readonly static string _conn = @"Data Source=DESKTOP-HTEOBRF\SQLEXPRESS;
            Initial Catalog=TCCG5;
            Integrated Security=True;
            Connect Timeout=30;
            Encrypt=False;
            TrustServerCertificate=False;
            ApplicationIntent=ReadWrite;
            MultiSubnetFailover=False";

        public int Id_secao { get; set; }

        public int Id_mesa { get; set; }

        public DateTime Data { get; set; }

        public MesaSecao() { }

        public MesaSecao(int id_secao, int id_mesa, DateTime data)
        {
            Id_secao = id_secao;
            Id_mesa = id_mesa;
            Data = data;
        }

        public static List<MesaSecao> GetMesaSecao()
        {
            var listaMesaSecao = new List<MesaSecao>();
            var sql = "SELECT * FROM mesa_secao";
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
                                    listaMesaSecao.Add(new MesaSecao(Convert.ToInt32(dr["id_secao"]),
                                        Convert.ToInt32(dr["id_mesa"]),
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
            return listaMesaSecao;
        }

        public void Salvar()
        {
            var iSQL = "";
            if (Id_secao == 0)
            {
                iSQL = "INSERT INTO mesa_secao (id_secao,id_mesa,data) VALUES(@id_secao,@id_mesa,@data)";
            }
            else
            {
                iSQL = "UPDATE secao SET id_secao=@id_secao,id_mesa=@id_mesa,data=@data WHERE id =";
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(iSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@id_secao", Id_secao);
                        cmd.Parameters.AddWithValue("@id_mesa", Id_mesa);
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
            var iSQL = "DELETE FROM mesa_secao WHERE id=" + Id_secao;
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

        public void GetMesaSecao(int id)
        {
            var sql = "SELECT * FROM mesa_secao WHERE id=" + id;
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
                                    Id_secao = Convert.ToInt32(dr["id_secao"]);
                                    Id_mesa = Convert.ToInt32(dr["id_mesa"]);
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