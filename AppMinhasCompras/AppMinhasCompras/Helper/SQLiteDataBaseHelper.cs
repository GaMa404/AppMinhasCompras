using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppMinhasCompras.Model;
using SQLite;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AppMinhasCompras.Helper
{
    public class SQLiteDataBaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQLiteDataBaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE produto SET descricao=?, quantidade=?, preco=? WHERE id=?";
            return _conn.QueryAsync<Produto>(sql, p.descricao, p.quantidade, p.preco, p.id);
        }

        /* public Task<Produto> GetById(int id)
        {
            return new Produto();
        } */

        public Task<List<Produto>> getAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Produto>().DeleteAsync(i => i.id == id);
        }

        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM produto WHERE descricao LIKE '%" + q + "%'";
            return _conn.QueryAsync<Produto>(sql);
        }
    }
}
