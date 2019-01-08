using Consultoria.Bee.Domain.Entities;
using Consultoria.Bee.Domain.Interfaces.Repositories;
using Consultoria.Bee.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace Consultoria.Bee.Domain.Services
{
    public class ProdutoService : GenericService<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public override async Task AddAsync(Produto obj)
        {
            // Validações.....
            await base.AddAsync(obj);
        }
    }
}
