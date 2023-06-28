using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Tpfc
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

        public int Id_setor {get; set;}
    
        public string Nome { get; set; }

        public string Setor { get; set; }

        public Tpfc() { }

        public Tpfc(int id, int id_setor, string nome, string setor)
        {
            Id = id;
            Id_setor = id_setor;
            Nome = nome;
            Setor = setor;
            
        }

        public static List<Tpfc> GetTpfc()
        {
            var listaTpfc = new List<Tpfc>();
            var sql = "SELECT * FROM tipofunc";
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
                                    listaTpfc.Add(new Tpfc(Convert.ToInt32(dr["id"]),
                                        Convert.ToInt32(dr["id_setor"]),
                                        Convert.ToString(dr["nome"]),
                                        Convert.ToString(dr["setor"])
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
            return listaTpfc;

        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO tipofunc (id_setor,nome,setor) VALUES(@id_setor,@nome,@setor)";
            }
            else
            {
                sql = "UPDATE tipofunc SET id_setor=@id_setor,nome=@nome,setor=@setor WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@id_setor", Id_setor);
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@setor", Setor);

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
            var iSQL = "DELETE FROM tipofunc WHERE id=" + Id;
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

        public void GetTpfc(int id)
        {
            var sql = "SELECT * FROM tipofunc WHERE id=" + id;
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
                                    Id_setor = Convert.ToInt32(dr["id_setor"]);
                                    Nome = Convert.ToString(dr["nome"]);
                                    Setor = Convert.ToString(dr["setor"]);

                                    

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