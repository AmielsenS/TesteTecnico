using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Models;

namespace DAL
{

    public class LivroDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["TesteTecnico2"].ConnectionString;


        //Método de Inserir Livro
        public void InserirLivro(Livro l)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "insert into Livros values (@f1,@f2,@f3,@f4,@f5,@f6); insert into Livros values (@f1, @f6)";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@f1", l.CodLivro);
            cmd.Parameters.AddWithValue("@f2", l.Editora);
            cmd.Parameters.AddWithValue("@f3", l.Nome);
            cmd.Parameters.AddWithValue("@f4", l.Autor);
            cmd.Parameters.AddWithValue("@f5", l.Ano);
            cmd.Parameters.AddWithValue("@f6", l.Preco);


            cmd.ExecuteNonQuery();
            conn.Close();


        }

        //Método de Atualização
        public void AtualizarLivro(Livro l)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "UPDATE Filme SET CodLivro = @b, Titulo = @t, Genero = @g, Ano = @a, ValorCusto = @c, Situacao = @s, Diretor = @d WHERE CodBarras = @cod";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@f1", l.CodLivro);
            cmd.Parameters.AddWithValue("@f2", l.Editora);
            cmd.Parameters.AddWithValue("@f3", l.Nome);
            cmd.Parameters.AddWithValue("@f4", l.Autor);
            cmd.Parameters.AddWithValue("@f5", l.Ano);
            cmd.Parameters.AddWithValue("@f6", l.Preco);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        //Método de Exclusão
        public void ExcluirLivro(int cod)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "Delete from Livros Where CodBarras = @algo";
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@algo", cod);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        //Método de Busca
        
        public Livro SelecionarFilmeWeb(string nome)
        {
            Livro objLivro = null;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            string sql = "SELECT * FROM Livros WHERE CodLivro = @l1";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@l1", nome);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows && dr.Read())
            {
                objLivro = new Livro();
                objLivro.CodLivro = Convert.ToInt32(dr["CodLivro"].ToString());
                objLivro.Editora = dr["Editora"].ToString();
                objLivro.Nome = dr["Nome"].ToString();
                objLivro.Autor = dr["Autor"].ToString();
                objLivro.Ano = Convert.ToDateTime(dr["Ano"]);
                objLivro.Preco = Convert.ToDecimal(dr["Preco"]);
            }

            conn.Close();

            return objLivro;
        }

        //Buscar livros na Tela Principal
        public Livro BuscarTelaPrincipal(int i)
        {
            Livro objWeb = null;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "select * from Livros where CodLivro = @l1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@l1", i);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                objWeb = new Livro();
                //objWeb.CdItem = Convert.ToInt32(dr["CodLivro"]);
                objWeb.Nome = dr["Nome"].ToString();

            }
            return objWeb;
        }
    }
}


