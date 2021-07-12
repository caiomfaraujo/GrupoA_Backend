using Dapper;
using Domain;
using Repository.Interface;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static Domain.MySqlSettings;

namespace Repository.Repository
{
    public class AlunoRepository : IAlunoRepository
    {        
        public MySqlDB Db { get; }

        public AlunoRepository(MySqlDB db)
        {
            Db = db;
        }

        public string InsertData(string nome, string identificacao, int RegistroAcademico)
        {
            string sql = string.Format("INSERT INTO Aluno(Nome, Identificacao, RegistroAcademico, DataCriacao, DataAtualizacao) values('{0}', '{1}', '{2}', CURRENT_TIMESTAMP(), CURRENT_TIMESTAMP());", nome, identificacao, RegistroAcademico);
            Log.Information("Executando a consulta: {sql}", sql);

            var query = Db.Connection.Execute(sql, new { Nome = nome, Identificacao = identificacao, RegistroAcademico = RegistroAcademico });
            Log.Information("Resultado da query: {query}", query);

            return "Aluno adicionado.";
        }

        public async Task<IEnumerable<Aluno>> GetAlunosData()
        {
            string sql = "select * from Aluno;";
            Log.Information("Executando a consulta: {sql}", sql);

            var query = Db.Connection.Query<Aluno>(sql);
            Log.Information("Resultado da query: {query}", query);

            return query;
        }

        public async Task<IEnumerable<Aluno>> GetAlunoData(int id)
        {
            string sql = String.Format("select * from Aluno where ID = {0};", id);
            Log.Information("Executando a consulta: {sql}", sql);

            var query = Db.Connection.Query<Aluno>(sql);
            Log.Information("Resultado da query: {query}", query);

            return query;
        }
        public string DeletaData(int id)
        {
            string sql = "DELETE FROM Aluno WHERE ID = @ID";
            Log.Information("Executando a consulta: {sql}", sql);

            var query = Db.Connection.Execute(sql, new { ID = id });
            Log.Information("Resultado da query: {query}", query);

            return "Aluno deletado.";
        }

        public int AtualizaAlunoData(int id, string nome, string identificacao, int RegistroAcademico)
        {
            var sql = "UPDATE Aluno SET Nome = @Nome, Identificacao = @Identificacao, RegistroAcademico = @RegistroAcademico, DataAtualizacao = CURRENT_TIMESTAMP() WHERE ID = @ID;";
            var count = Db.Connection.Execute(sql, new { ID = id, Nome = nome, Identificacao = identificacao, RegistroAcademico = RegistroAcademico });
            return count;
        }
    }
}
