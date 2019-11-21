using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contratos;
using Entidades.Models;
using GrulesWebAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrulesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AlunoController(ILoggerManager logger, IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _logger = logger;
            _repo = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarTodosAlunos()
        {
            try
            {
                IEnumerable<Aluno> result = _repo.Aluno.ListarTodosAlunos();
                _logger.LogInfo($"Obter todos os alunos do banco.");

                IEnumerable<AlunoModel> alunos = _mapper.Map<IEnumerable<AlunoModel>>(result);

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter todos os alunos: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{idAluno}", Name = "ObterAlunoPorId")]
        public IActionResult ObterAlunoPorId(int idAluno)
        {
            try
            {
                Aluno result = _repo.Aluno.ObterAlunoPorId(idAluno);

                if (result == null)
                {
                    _logger.LogInfo($"Erro ao obter o aluno de id: {idAluno}.");
                    return NotFound();
                }

                _logger.LogInfo($"Obter o aluno {result.Nome} do banco.");
                AlunoModel aluno = _mapper.Map<AlunoModel>(result);

                return Ok(aluno);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o aluno: {idAluno} - {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult SalvarAluno([FromBody]AlunoModel alunoModel)
        {
            try
            {
                if (alunoModel == null)
                {
                    _logger.LogError("Objeto 'Aluno' enviado pelo cliente é nulo.");
                    return BadRequest("Objeto nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto inválido.");
                    return BadRequest("Objeto inválido");
                }

                Aluno aluno = _mapper.Map<Aluno>(alunoModel);

                _repo.Aluno.SalvarAluno(aluno);    
                _repo.Save();
                _logger.LogInfo($"O aluno: {aluno.IdAluno}, foi criado/alterado.");

                AlunoModel alunoCriado = _mapper.Map<AlunoModel>(aluno);

                if (alunoModel.IdAluno > 0)
                {
                    return CreatedAtRoute("ObterAlunoPorId", new { idAluno = alunoCriado.IdAluno }, alunoCriado);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar aluno: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{idAluno}")]
        public IActionResult ExcluirAluno(int idAluno)
        {
            try
            {
                var aluno = _repo.Aluno.ObterAlunoPorId(idAluno);
                if (aluno == null)
                {
                    _logger.LogError($"O aluno com o id: {idAluno}, não foi encontrado no banco.");
                    return NotFound();
                }

                _repo.Aluno.ExcluirAluno(aluno);
                _logger.LogInfo($"O aluno: {aluno.Nome}, foi excluido do banco.");
                _repo.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir aluno: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}