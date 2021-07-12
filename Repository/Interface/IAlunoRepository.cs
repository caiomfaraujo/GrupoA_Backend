using Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAlunoRepository
    {
        string InsertData(string nome, string identificacao, int RegistroAcademico);
        Task<IEnumerable<Aluno>> GetAlunosData();
        Task<IEnumerable<Aluno>> GetAlunoData(int id);
        string DeletaData(int id);
        int AtualizaAlunoData(int id, string nome, string identificacao, int RegistroAcademico);
    }
}
