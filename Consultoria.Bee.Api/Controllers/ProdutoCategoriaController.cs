using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultoria.Bee.Domain.Entities;
using Consultoria.Bee.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Consultoria.Bee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoCategoriaController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IProdutoCategoriaService _produtoCategoriaService;

        public ProdutoCategoriaController(ILogger<ProdutoCategoriaController> logger, IProdutoCategoriaService produtoCategoriaService)
        {
            _logger = logger;
            _produtoCategoriaService = produtoCategoriaService;
        }

        // GET: api/ProdutoCategoria
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoCategoria>>> Get()
        {
            return await _produtoCategoriaService.GetAllAsync();
        }

        // GET: api/ProdutoCategoria/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ProdutoCategoria
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoCategoria produtoCategoria)
        {
            try
            {
                await _produtoCategoriaService.AddAsync(produtoCategoria);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro", produtoCategoria);
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

        // PUT: api/ProdutoCategoria/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
