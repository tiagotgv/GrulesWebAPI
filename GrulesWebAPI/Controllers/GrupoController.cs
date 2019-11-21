using AutoMapper;
using Contratos;
using Entidades.Models;
using GrulesWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GrulesWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public GrupoController(ILoggerManager logger, IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _logger = logger;
            _repo = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarTodosGrupos()
        {
            try
            {
                IEnumerable<Grupo> result = _repo.Grupo.ListarTodosGrupos();
                _logger.LogInfo($"Obter todos os grupos do banco.");

                IEnumerable<GrupoModel> grupos = _mapper.Map<IEnumerable<GrupoModel>>(result);

                return Ok(grupos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter todos os grupos: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{idGrupo}", Name = "ObterGrupoPorId")]
        public IActionResult ObterGrupoPorId(int idGrupo)
        {
            try
            {
                Grupo result = _repo.Grupo.ObterGrupoPorId(idGrupo);

                if (result == null)
                {
                    _logger.LogInfo($"Erro ao obter o grupo de id: {idGrupo}.");
                    return NotFound();
                }

                _logger.LogInfo($"Obter o grupo {result.IdGrupo} do banco.");
                GrupoModel grupo = _mapper.Map<GrupoModel>(result);

                return Ok(grupo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o grupo: {idGrupo} - {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult SalvarGrupo([FromBody]GrupoModel grupoModel)
        {
            try
            {
                if (grupoModel == null)
                {
                    _logger.LogError("Objeto 'Grupo' enviado pelo cliente é nulo.");
                    return BadRequest("Objeto nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto inválido.");
                    return BadRequest("Objeto inválido");
                }

                Grupo grupo = _mapper.Map<Grupo>(grupoModel);

                _repo.Grupo.SalvarGrupo(grupo);
                _repo.Save();
                _logger.LogInfo($"O aluno: {grupo.IdGrupo}, foi criado/alterado.");

                GrupoModel grupoCriado = _mapper.Map<GrupoModel>(grupo);

                if (grupoModel.IdGrupo > 0)
                {
                    return CreatedAtRoute("ObterGrupoPorId", new { idGrupo = grupoCriado.IdGrupo }, grupoCriado);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar grupo: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{idGrupo}")]
        public IActionResult ExcluirGrupo(int idGrupo)
        {
            try
            {
                var grupo = _repo.Grupo.ObterGrupoPorId(idGrupo);
                if (grupo == null)
                {
                    _logger.LogError($"O grupo com o id: {idGrupo}, não foi encontrado no banco.");
                    return NotFound();
                }

                _repo.Grupo.ExcluirGrupo(grupo);
                _logger.LogInfo($"O aluno: {grupo.IdGrupo}, foi excluido do banco.");
                _repo.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir grupo: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}