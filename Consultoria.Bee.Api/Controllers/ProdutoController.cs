using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consultoria.Bee.Domain.Entities;
using Consultoria.Bee.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Consultoria.Bee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> Get()
        {
            return await _produtoService.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(int id)
        {
            return await _produtoService.GetByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Produto produto)
        {
            try
            {
                await _produtoService.AddAsync(produto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro", produto);
                return BadRequest(
                    new
                    {
                        Error = "Ocorreu um erro não tratado antes de inserir o registro. Tente novamente mais tarde! Se o problema persistir entre em contato com o suporte técnico.",
                        ex.Message,
                        ex.InnerException
                    }
                );
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
