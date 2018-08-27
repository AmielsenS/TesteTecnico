using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace Models
{
    public class Livro
    {
        public int CodLivro { get; set; }

        public string Editora { get; set; }

        public string Nome { get; set; }

        public string Autor { get; set; }

        public DateTime Ano { get; set; }

        public decimal Preco { get; set; }
    }
}
