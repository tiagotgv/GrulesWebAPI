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
    public class EventoController : ControllerBase
    {
        private readonly IRepositoryWrapper _repo;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EventoController(ILoggerManager logger, IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _logger = logger;
            _repo = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarTodosEventos()
        {
            try
            {
                IEnumerable<Evento> result = _repo.Evento.ListarTodosEventos();
                _logger.LogInfo($"Obter todos os eventos do banco.");

                IEnumerable<EventoModel> eventos = _mapper.Map<IEnumerable<EventoModel>>(result);

                return Ok(eventos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter todos os eventos: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{idEvento}", Name = "ObterEventoPorId")]
        public IActionResult ObterEventoPorId(int idEvento)
        {
            try
            {
                Evento result = _repo.Evento.ObterEventoPorId(idEvento);

                if (result == null)
                {
                    _logger.LogInfo($"Erro ao obter o Evento de id: {idEvento}.");
                    return NotFound();
                }

                _logger.LogInfo($"Obter o Evento {result.IdEvento} do banco.");
                EventoModel evento = _mapper.Map<EventoModel>(result);

                return Ok(evento);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro ao obter o Evento: {idEvento} - {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult SalvarEvento([FromBody]EventoModel eventoModel)
        {
            try
            {
                if (eventoModel == null)
                {
                    _logger.LogError("Objeto 'Evento' enviado pelo cliente é nulo.");
                    return BadRequest("Objeto nulo");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Objeto inválido.");
                    return BadRequest("Objeto inválido");
                }

                Evento evento = _mapper.Map<Evento>(eventoModel);

                _repo.Evento.SalvarEvento(evento);
                _repo.Save();
                _logger.LogInfo($"O aluno: {evento.IdEvento}, foi criado/alterado.");

                EventoModel eventoCriado = _mapper.Map<EventoModel>(evento);

                if (eventoModel.IdEvento > 0)
                {
                    return CreatedAtRoute("ObterEventoPorId", new { idEvento = eventoCriado.IdEvento }, eventoCriado);
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao criar evento: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{idEvento}")]
        public IActionResult ExcluirAluno(int idEvento)
        {
            try
            {
                var evento = _repo.Evento.ObterEventoPorId(idEvento);
                if (evento == null)
                {
                    _logger.LogError($"O Evento com o id: {idEvento}, não foi encontrado no banco.");
                    return NotFound();
                }

                _repo.Evento.ExcluirEvento(evento);
                _logger.LogInfo($"O aluno: {evento.IdEvento}, foi excluido do banco.");
                _repo.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir evento: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}