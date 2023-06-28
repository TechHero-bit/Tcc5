using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Secao
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

        public Secao() { }

        public Secao(int id, int numero)
        {
            Id = id;
            Numero = numero;
        }

        public static List<Secao> GetSecao()
        {
            var listaSecao = new List<Secao>();
            var sql = "SELECT * FROM secao";
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
                                    listaSecao.Add(new Secao(Convert.ToInt32(dr["id"]),
                                        Convert.ToInt32(dr["numero"])
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
            return listaSecao;

        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO secao (id, numero) VALUES(@id,@numero)";
            }
            else
            {
                sql = "UPDATE secao SET  id=@id,numero=@numero WHERE id =";        
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
            var sql = "DELETE FROM secao WHERE id=" + Id;
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

        public void GetSecao(int id)
        {
            var sql = "SELECT * FROM secao WHERE id=" + id;
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
                                    Id = Convert.ToInt32(dr["id"]);
                                    Numero = Convert.ToInt32(dr["numero"]);
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