using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contratos;
using Contratos.Interfaces;
using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GrulesWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IRepositoryWrapper _repo;
        private readonly ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repo = repoWrapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Nova requisição (GET).");
            IEnumerable<Aluno> alunos = _repo.Aluno.ListarTodosAlunos();

            return alunos.Select(x => x.Nome);
        }
    }
}
