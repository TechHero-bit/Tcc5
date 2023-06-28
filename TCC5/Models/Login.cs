using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Login
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

        public int Id_tipofunc { get; set; }

        public int Id_secao { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public int Setor { get; set; }

        public Login() { }

        public Login(int id, int id_tipofunc, int id_secao,string cpf, string nome, string senha, int setor)
        {
            Id = id;
            Id_tipofunc = id_tipofunc;
            Id_secao = id_secao;
            Cpf = cpf;
            Nome = nome;
            Senha = senha;
            Setor = setor;
        }

        public static List<Login> GetLogin()
        {
            var listaLogin = new List<Login>();
            var sql = "SELECT * FROM login";
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
                                    listaLogin.Add(new Login(Convert.ToInt32(dr["id"]),
                                        Convert.ToInt32(dr["id_tipofunc"]),
                                       Convert.ToInt32(dr["id_secao"]),
                                        Convert.ToString(dr["cpf"]),
                                        Convert.ToString(dr["nome"]),
                                        Convert.ToString(dr["senha"]),
                                        Convert.ToInt32(dr["setor"])
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
            return listaLogin;

        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO login (id_tipofunc,id_secao,cpf,nome,senha,setor) VALUES(@id_tipofunc,@id_secao, @cpf, @nome,  @senha,@setor)";
            }
            else
            {
                sql = "UPDATE login SET id_tipofunc=@id_tipofunc,id_secao=@id_secao,cpf=@cpf,nome=@nome ,senha=@senha,setor=@setor WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@id_tipofunc", Id_tipofunc);
                        cmd.Parameters.AddWithValue("@id_secao", Id_secao);
                        cmd.Parameters.AddWithValue("@cpf", Cpf);
                        cmd.Parameters.AddWithValue("@nome", Nome);
                        cmd.Parameters.AddWithValue("@senha", Senha);
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
            var iSQL = "DELETE FROM login WHERE id=" + Id;
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

        public void GetLogin(int id)
        {
            var sql = "SELECT * FROM login WHERE id=" + id;
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
                                    Id_tipofunc = Convert.ToInt32(dr["id_tipofunc"]);
                                    Id_secao = Convert.ToInt32(dr["id_secao"]);
                                    Cpf = Convert.ToString(dr["cpf"]);
                                    Nome = Convert.ToString(dr["nome"]);
                                    Senha = Convert.ToString(dr["senha"]);
                                    Setor = Convert.ToInt32(dr["setor"]);

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