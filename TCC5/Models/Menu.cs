using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Menu
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
        public int Item_Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public DateTime DataC { get; set; }

        public Menu() { }

        public Menu(int id, int item_id, string descricao, Decimal valor, DateTime datac)
        {
            Id = id;
            Item_Id = item_id;
            Descricao = descricao;
            Valor = valor;
            DataC = datac;
        }

        public static List<Menu> GetCardapio()
        {
            var listaCardapio = new List<Menu>();
            var sql = "SELECT * FROM menu";
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
                                    listaCardapio.Add(new Menu(Convert.ToInt32(dr["id"]),
                                        Convert.ToInt32(dr["item_id"]),
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
            return listaCardapio;

        }

        public void Salvar()
        {
            var iSQL = "";
            if (Id == 0)
            {
                iSQL = "INSERT INTO menu (item_id,descricao,valor,data) VALUES(@item_id, @descricao, @valor,  @data)";
            }
            else
            {
                iSQL = "UPDATE menu SET item_id=@item_id ,descricao=@descricao,valor=@valor ,data = @data WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(iSQL, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@item_id", Item_Id);
                        cmd.Parameters.AddWithValue("@descricao", Descricao);
                        cmd.Parameters.AddWithValue("@valor", Valor);
                        cmd.Parameters.AddWithValue("@Data", DataC);

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
            var iSQL = "DELETE FROM menu WHERE id=" + Id;
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

        public void GetCardapio(int id)
        {
            var sql = "SELECT * FROM menu WHERE id=" + id;
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
                                    Item_Id = Convert.ToInt32(dr["item_id"]);
                                    Descricao = Convert.ToString(dr["descricao"]);
                                    Valor = Convert.ToDecimal(dr["valor"]);
                                    DataC = Convert.ToDateTime(dr["data"]);

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
