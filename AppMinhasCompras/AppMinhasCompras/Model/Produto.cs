using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMinhasCompras.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string descricao { get; set; }
        public double quantidade { get; set; }
        public double preco { get; set; }
    }
}
