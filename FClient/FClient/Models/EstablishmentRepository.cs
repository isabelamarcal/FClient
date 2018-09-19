using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FClient.Models
{
    public class EstablishmentRepository : AbstractRepository<Establishment, int>
    {
        ///<summary>Exclui uma pessoa pela entidade
        ///<param name="entity">Referência de Pessoa que será excluída.</param>
        ///</summary>
        public override void Delete(Establishment entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "DELETE Establishment Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        

        ///<summary>Obtém todas as pessoas
        ///<returns>Retorna as pessoas cadastradas.</returns>
        ///</summary>
        public override List<Establishment> GetAll()
        {
            string sql = "Select Id, Nome, Email, Cidade, Endereco FROM Pessoa ORDER BY Nome";
            using (var conn = new SqlConnection(StringConnection))
            {
                var cmd = new SqlCommand(sql, conn);
                List<Establishment> list = new List<Establishment>();
                Establishment p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            p = new Establishment();
                            p.Id = new Guid(reader["Id"].ToString());
                            p.SocialName = reader["SocialName"].ToString();
                            p.FantasyName = reader["FantasyName"].ToString();
                            p.CNPJ = reader["CNPJ"].ToString();
                            p.Email = reader["Email"].ToString();
                            p.Address = reader["Address"].ToString();
                            p.City = reader["City"].ToString();
                            p.State = reader["State"].ToString();
                            p.Phone = reader["Phone"].ToString();
                            p.DateTime = DateTime.Parse(reader["DateTime"].ToString());
                            p.Category = reader["Category"].ToString();
                            p.IsActive = Convert.ToBoolean(reader["Endereco"]);
                            p.Agency = reader["Agency"].ToString();
                            p.Account = reader["Account"].ToString();


                            list.Add(p);
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return list;
            }
        }

        ///<summary>Obtém uma pessoa pelo ID
        ///<param name="id">Id do registro que obtido.</param>
        ///<returns>Retorna uma referência de Pessoa do registro encontrado ou null se ele não for encontrado.</returns>
        ///</summary>
        public override Establishment GetById(int id)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "Select Id, Nome, Email, Cidade, Endereco FROM Pessoa WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                Establishment p = null;
                try
                {
                    conn.Open();
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                p = new Pessoa();
                                p.Id = (int)reader["Id"];
                                p.Nome = reader["Nome"].ToString();
                                p.Email = reader["Email"].ToString();
                                p.Cidade = reader["Cidade"].ToString();
                                p.Endereco = reader["Endereco"].ToString();
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                return p;
            }
        }

        ///<summary>Salva a pessoa no banco
        ///<param name="entity">Referência de Pessoa que será salva.</param>
        ///</summary>
        public override void Save(Pessoa entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "INSERT INTO Pessoa (Nome, Email, Cidade, Endereco) VALUES (@Nome, @Email, @Cidade, @Endereco)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        ///<summary>Atualiza a pessoa no banco
        ///<param name="entity">Referência de Pessoa que será atualizada.</param>
        ///</summary>
        public override void Update(Pessoa entity)
        {
            using (var conn = new SqlConnection(StringConnection))
            {
                string sql = "UPDATE Pessoa SET Nome=@Nome, Email=@Email, Cidade=@Cidade, Endereco=@Endereco Where Id=@Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", entity.Id);
                cmd.Parameters.AddWithValue("@Nome", entity.Nome);
                cmd.Parameters.AddWithValue("@Email", entity.Email);
                cmd.Parameters.AddWithValue("@Cidade", entity.Cidade);
                cmd.Parameters.AddWithValue("@Endereco", entity.Endereco);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
