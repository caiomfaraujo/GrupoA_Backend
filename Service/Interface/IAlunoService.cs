using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAlunoService
    {
        string AddAluno(string nome, string identificacao, int RegistroAcademico);
        Task<IEnumerable<Aluno>> GetAlunos();
        Task<IEnumerable<Aluno>> GetAluno(int id);
        string DeletaAluno(int id);
        int AtualizaAluno(int id, string nome, string identificacao, int RegistroAcademico);
    }
}