using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TCC5.Models
{
    public class Comanda
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

        public int Mesa_id { get; set; }

        public int Id_couvert { get; set; }

        public DateTime Data { get; set; }

        public Decimal Valor_comanda { get; set; }

        public Decimal Lei_da_gorjeta { get; set; }

        public Decimal Desconto { get; set; }

        public string Justificativa_desconto { get; set; }

        public Comanda() { }

        public Comanda(int id, int mesa_id, int id_couvert, DateTime data, Decimal valor_comanda, Decimal lei_da_gorjeta, Decimal desconto, string justificativa_desconto)
        {
            Id = id;
            Mesa_id = mesa_id;
            Id_couvert = id_couvert;
            Data = data;
            Valor_comanda = valor_comanda;
            Lei_da_gorjeta = lei_da_gorjeta;
            Desconto = desconto;
            Justificativa_desconto = justificativa_desconto;
        }

        public static List<Comanda> GetComanda()
        {
            var listaComanda = new List<Comanda>();
            var sql = "SELECT * FROM comanda";
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
                                    listaComanda.Add(new Comanda(Convert.ToInt32(dr["id"]),
                                        Convert.ToInt32(dr["mesa_id"]),
                                       Convert.ToInt32(dr["id_couvert"]),
                                        Convert.ToDateTime(dr["data"]),
                                        Convert.ToDecimal(dr["valor_comanda"]),
                                        Convert.ToDecimal(dr["lei_da_gorjeta"]),
                                        Convert.ToDecimal(dr["desconto"]),
                                        Convert.ToString(dr["justificativa_desconto"])
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
            return listaComanda;

        }

        public void Salvar()
        {
            var sql = "";
            if (Id == 0)
            {
                sql = "INSERT INTO comanda (mesa_id,id_couvert,data,valor_comanda,lei_da_gorjeta,desconto,justificativa_desconto) VALUES(@mesa_id, @id_couvert,@data, @valor_comanda,lei_da_gorjeta,desconto,justificativa_desconto  )";
            }
            else
            {
                sql = "UPDATE comanda SET mesa_id=@mesa_id ,id_couvert=@id_couvert,data=@data,valor_comanda=@valor_comanda,lei_da_gorjeta=@lei_da_gorjeta,desconto=@desconto,justificativa_desconto=@justificativa_desconto WHERE id =" + Id;
            }
            try
            {
                using (var cn = new SqlConnection(_conn))
                {
                    cn.Open();
                    using (var cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@id", Id);
                        cmd.Parameters.AddWithValue("@mesa_id", Mesa_id);
                        cmd.Parameters.AddWithValue("@id_couvert", Id_couvert);
                        cmd.Parameters.AddWithValue("@data", Data);
                        cmd.Parameters.AddWithValue("@valor_comanda", Valor_comanda);
                        cmd.Parameters.AddWithValue("@lei_da_gorjeta", Lei_da_gorjeta);
                        cmd.Parameters.AddWithValue("@desconto", Desconto);
                        cmd.Parameters.AddWithValue("@justificativa_desconto", Justificativa_desconto);


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
            var sql = "DELETE FROM comanda WHERE id=" + Id;
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

        public void GetComanda(int id)
        {
            var sql = "SELECT * FROM comanda WHERE id=" + id;
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
                                    Mesa_id = Convert.ToInt32(dr["mesa_id"]);
                                    Id_couvert = Convert.ToInt32(dr["id_couvert"]);
                                    Data = Convert.ToDateTime(dr["data"]);
                                    Valor_comanda = Convert.ToDecimal(dr["valor_comanda"]);
                                    Lei_da_gorjeta = Convert.ToDecimal(dr["lei_da_gorjeta"]);
                                    Desconto = Convert.ToDecimal(dr["desconto"]);
                                    Justificativa_desconto = Convert.ToString(dr["justificativa_desconto"]);

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