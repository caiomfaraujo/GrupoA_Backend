using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.Interface;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : Controller
    {
        private IAlunoService _aluno;

        public AlunoController(IAlunoService aluno)
        {
            _aluno = aluno;
        }

        [HttpPost]
        [Route("addaluno")]
        public async Task<IActionResult> Addaluno(string nome, string identificacao, int RegistroAcademico)
        {
            try
            {
                string retorno = _aluno.AddAluno(nome, identificacao, RegistroAcademico);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return BadRequest(err);
            }
        }

        [HttpGet]
        [Route("listaalunos")]
        public async Task<IActionResult> Getalunos()
        {
            try
            {
                return Ok(await _aluno.GetAlunos()); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("listaaluno")]
        public async Task<IActionResult> Getaluno(int id)
        {
            try
            {
                return Ok(await _aluno.GetAluno(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deletaaluno")]
        public async Task<IActionResult> Deletaaluno(int id)
        {
            try
            {
                string retorno = _aluno.DeletaAluno(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
                return BadRequest(err);
            }
        }

        [HttpPut]
        [Route("atualizaaluno")]
        public async Task<IActionResult> Atualizaaluno(int id, string nome, string identificacao, int RegistroAcademico)
        {
            try
            {
                var count = _aluno.AtualizaAluno(id, nome, identificacao, RegistroAcademico);
                if (count > 0)
                {
                    return Ok("O aluno foi atualizado.");
                }
                else
                {
                    return Ok("Nenhum registro foi atualizado.");
                }
            }
            catch (Exception ex)
            {
                Log.Information("Erro: {0}", ex);
                return BadRequest("Erro.");
            }
        }
    }
}
