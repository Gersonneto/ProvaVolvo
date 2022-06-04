using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProvaVolvo.Application.Caminhoes;
using ProvaVolvo.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaVolvo.Api.Controllers
{
    [Route("api/caminhoes")]
    [ApiController]
    public class ApiCaminhoes : ControllerBase
    {
        private readonly ILogger<ApiCaminhoes> _logger;
        private readonly CaminhoesService _service;
        public ApiCaminhoes(ILogger<ApiCaminhoes> logger, CaminhoesService service)
        {
            this._logger = logger;
            this._service = service;
            
        }

        [HttpGet]
        public ActionResult<IEnumerable<CaminhaoDTO>> Listar()
        {
            try
            {
                _logger.LogInformation("Recebendo requisição de listar todos os processos.");
                var resultado = this._service.ListarTodos();
                _logger.LogInformation("Retornando requisição de listar todos os processos.");
                return Ok(resultado);

            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição: " + e.Message);
                throw e;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<CaminhaoDTO> Listar(long id)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição de listar um caminhão.");
                var resultado = this._service.ListarPorId(id);
                _logger.LogInformation("Retornando requisição de listar um processo.");
                return Ok(resultado);

            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição :" + e.Message);
                throw e;
            }
        }

        [HttpPost("cadastrar")]
        public ActionResult Cadastrar([FromBody] CaminhaoDTO caminhao)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição para cadastrar um processo.");
                this._service.Cadastrar(caminhao);
                _logger.LogInformation("Retornando requisição para cadastrar um processo.");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição: " + e.Message);
                throw e;
            }
        }

        [HttpPut("atualizar")]
        public ActionResult Atualizar([FromBody] CaminhaoDTO caminhao)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição para cadastrar um processo.");
                this._service.Atualizar(caminhao);
                _logger.LogInformation("Retornando requisição para cadastrar um processo.");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição: " + e.Message);
                throw e;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult Deletar(long id)
        {
            try
            {
                _logger.LogInformation("Recebendo requisição de listar um caminhão.");
                this._service.Deletar(id);
                _logger.LogInformation("Retornando requisição de listar um processo.");
                return Ok();

            }
            catch (Exception e)
            {
                _logger.LogError("Falha na requisição :" + e.Message);
                throw e;
            }
        }


    }
}
