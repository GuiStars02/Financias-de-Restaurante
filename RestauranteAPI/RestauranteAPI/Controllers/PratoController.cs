using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Data.Models;
using RestauranteAPI.Services.Interfaces;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PratoController : ControllerBase
    {
        private readonly IPratoService _service;

        public PratoController(IPratoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPratos()
        {
            try
            {
                return Ok(await _service.GetAll());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{idPrato:int}", Name = "ObterPrato")]
        public async Task<IActionResult> GetPratoById(int idPrato)
        {
            try
            {
                var prato = await _service.GetPratoById(idPrato);
                if(prato is null)
                {
                    return NotFound($"Prato com o id: {idPrato} não encontrado");
                }

                return Ok(prato);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrato(Prato prato)
        {
            try
            {
                if(prato is null)
                {
                    return BadRequest("Dados inválidos");
                }

                var pratoCreated = await _service.CreatePrato(prato);
                return new CreatedAtRouteResult("ObterPrato", new { id = prato.IdPrato}, prato);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{idPrato:int}")]
        public async Task<IActionResult> UpdatePrato(int idPrato, Prato prato)
        {
            try
            {
                if (prato.IdPrato != idPrato)
                {
                    return BadRequest("Dados inválidos");
                }

                await _service.UpdatePrato(prato);
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{idPrato:int}")]
        public async Task<IActionResult> DeletePrato(int idPrato)
        {
            try
            {
                var result = await _service.DeletePrato(idPrato);
                if(result)
                {
                    return Ok("Produto excluído com sucesso");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir prato de id: {idPrato}");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
