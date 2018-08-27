using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using System.Web;
using DAL;

namespace GUI
{
    public partial class frmCadastroLivro : Form
    {
        public frmCadastroLivro()
        {
            InitializeComponent();
        }

        //Botão Inserir Livro
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Livro objLivro = new Livro();

            objLivro.CodLivro = Convert.ToInt32(txtCdBarra.Text);
            objLivro.Nome = txtTitulo.Text;
            objLivro.Editora = txtEditora.Text;
            objLivro.Autor = txtAutor.Text;
            objLivro.Ano = dtpLancamento.Value;
            objLivro.Preco = Convert.ToDecimal(nupValor.Value);

            LivroDAL lDal = new LivroDAL();
            lDal.InserirLivro(objLivro);

            MessageBox.Show("Livro foi Inserido com Sucesso!");

        }

        // Botão Editar Livro
        private void btnEditar_Click(object sender, EventArgs e)
        {
            Livro objLivro = new Livro();

            objLivro.CodLivro = Convert.ToInt32(txtCdBarra.Text);
            objLivro.Nome = txtTitulo.Text;
            objLivro.Editora = txtEditora.Text;
            objLivro.Autor = txtAutor.Text;
            objLivro.Ano = dtpLancamento.Value;
            objLivro.Preco = Convert.ToDecimal(nupValor.Value);

            LivroDAL lDal = new LivroDAL();
            lDal.AtualizarLivro(objLivro);

            MessageBox.Show("Livro foi Atualizado com Sucesso!");
        }

        //Botão Apagar Registro
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int CodLivro = Convert.ToInt32(txtCdBarra.Text);

            LivroDAL lDAL = new LivroDAL();
            lDAL.ExcluirLivro(CodLivro);

            MessageBox.Show("Livro foi removido com Sucesso!");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string Codigo = txtCdBarra.Text;

            LivroDAL lDAL = new LivroDAL();
            Livro objLivro = lDAL.SelecionarFilmeWeb(Codigo);

            txtEditora.Text = objLivro.Editora;
            txtAutor.Text = objLivro.Autor;
            txtTitulo.Text = objLivro.Nome;
            dtpLancamento.Value = Convert.ToDateTime(objLivro.Ano);
            nupValor.Value = Convert.ToDecimal(objLivro.Preco);


        }
    }
}
