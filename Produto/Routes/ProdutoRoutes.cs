using Produto.Data;
using Produto.Model;
using Produto.Services;

namespace Produto.Routes
{
    public static class ProdutoRoutes
    {
        public static void ProdutosRoutes(this WebApplication app)
        {
            var route = app.MapGroup("Produto");

            route.MapGet("", async (ProdutoService service) => 
            {
                return await service.BuscaProdutoAsync();
            });

            route.MapGet("{id:guid}", async (Guid id,ProdutoService service) => 
            {
                return await service.BuscaProdutoAsync(id);
            });

            route.MapPost("", async (ProdutoRequest req, ProdutoService service) => 
            {
                return await service.CadastrarProdutoAsync(req);
            });

            route.MapPut("{id:guid}", async (Guid id, ProdutoService service, ProdutoRequest req) => 
            {
                return await service.ModificarProdutoAsync(id, req);
            });

            route.MapDelete("{id:guid}", async (Guid id, ProdutoService service) => 
            {
                return await service.RemoverProdutoAsync(id);
            });
        }
    }
}
