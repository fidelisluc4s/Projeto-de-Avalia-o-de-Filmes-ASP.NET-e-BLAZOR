using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticaApi.Models;
using Dapper;
using System.Text;
using MySql.Data.MySqlClient;

namespace CriticaApi.DAOs
{
    public abstract class BaseDAO<T> where T : IModel
    {
        public abstract string NomeTabela { get; }
        public abstract Mapa[] Mapas { get; }

        public async Task InserirAsync(T obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Id))
                obj.Id = Guid.NewGuid().ToString();

            using (var conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"INSERT INTO {NomeTabela}" +
                                    $" (id{GetInsertNomes()})" +
                                    $" VALUES (@Id{GetInsertValores()})";

                await conexao.ExecuteAsync(sql, obj);
            }
        }

        public async Task AlterarAsync(T obj)
        {
            using (var conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"UPDATE {NomeTabela}" +
                    $" SET {GetUpdate()}" +
                    " WHERE id = @Id";

                await conexao.ExecuteAsync(sql, obj);
            }
        }

        public async Task ExcluirAsync(string id)
        {
            using (var conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"DELETE FROM {NomeTabela} WHERE id = @Id";

                await conexao.ExecuteAsync(sql, new { Id = id });
            }
        }

        public async Task<IList<T>> RetornarTodosAsync()
        {
            using (var conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"SELECT * FROM {NomeTabela}";

                var objetos = await conexao.QueryAsync<T>(sql);

                return objetos.ToList();
            }
        }

        public async Task<T> RetornarPorIdAsync(string id)
        {
            using (var conexao = new MySqlConnection(GetStringConexao()))
            {
                conexao.Open();

                string sql = $"SELECT * FROM {NomeTabela} WHERE id = @Id";

                var obj = await conexao.QuerySingleAsync<T>(sql, new { Id = id });

                return obj;
            }
        }

        private string GetInsertValores()
        {
            var sb = new StringBuilder();

            foreach (var mapa in Mapas)
                sb.Append($", @{mapa.Propriedade}");

            return sb.ToString();
        }

        private string GetInsertNomes()
        {
            var sb = new StringBuilder();

            foreach (var mapa in Mapas)
                sb.Append($", {mapa.Campo}");

            return sb.ToString();
        }

        private string GetUpdate()
        {
            var sb = new StringBuilder();

            foreach (var mapa in Mapas)
                sb.Append($", {mapa.Campo}=@{mapa.Propriedade}");

            return sb.ToString().Substring(1);
        }

        private static string GetStringConexao() =>
            "Server=127.0.0.1;Database=critica;Uid=root;Pwd=vini0105;";
    }

    public class Mapa
    {
        public string Propriedade { get; set; } = "";
        public string Campo { get; set; } = "";
    }
}
