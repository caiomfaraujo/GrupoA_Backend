using Domain;
using Repository.Interface;
using Serilog;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{    
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository repository;

        public AlunoService(IAlunoRepository repository)
        {
            this.repository = repository;
        }
        public string AddAluno(string nome, string identificacao, int RegistroAcademico)
        {
            try
            {
                repository.InsertData(nome, identificacao, RegistroAcademico);
                return "Aluno adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                Log.Information("Ocorreu um erro: {0}", ex);
                string err = ex.ToString();
                return err;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            try
            {
                return await repository.GetAlunosData();
            }
            catch (Exception ex)
            {
                Log.Information("Caiu na excessão: {0}", ex);
                return (IEnumerable<Aluno>)ex;
            }
        }

        public async Task<IEnumerable<Aluno>> GetAluno(int id)
        {
            try
            {
                return await repository.GetAlunoData(id);
            }
            catch (Exception ex)
            {
                Log.Information("Caiu na excessão: {0}", ex);
                return (IEnumerable<Aluno>)ex;
            }
        }

        public string DeletaAluno(int id)
        {
            try
            {
                repository.DeletaData(id);
                return "Aluno deletado com sucesso.";
            }
            catch (Exception ex)
            {
                Log.Information("Ocorreu um erro: {0}", ex);
                string err = ex.ToString();
                return err;
            }
        }

        public int AtualizaAluno(int id, string nome, string identificacao, int RegistroAcademico)
        {
            try
            {
                var count = repository.AtualizaAlunoData(id, nome, identificacao, RegistroAcademico);
                return count;
            }
            catch (Exception ex)
            {
                Log.Information("Caiu na excessão: {0}", ex);
                return 0;
            }
        }
    }
}
