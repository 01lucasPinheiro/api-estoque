using Microsoft.EntityFrameworkCore;
using Produto.Data;
using Produto.Model;

namespace Produto.Services
{
    public class ProdutoService
    {
        private readonly ProdutoContext _context;
       public ProdutoService(ProdutoContext context)
        {
            _context = context;
        }

        public async Task<IResult> BuscaProdutoAsync()
        {
            var produtos = await _context.Produtos.ToListAsync();

            return Results.Ok(produtos);
        }

        public async Task<IResult> BuscaProdutoAsync(Guid id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return Results.NotFound("Produto não encontrado");

            return Results.Ok(produto);
        }

        public async Task<IResult> CadastrarProdutoAsync(ProdutoRequest req) 
        {
            if (req.preco <= 0)
                return Results.BadRequest("Produto nao pode ser negativo ou zero");
            if (req.qtd < 0)
                return Results.BadRequest("Quantidade invalida");
            if(string.IsNullOrEmpty(req.nome))
                return Results.BadRequest("O nome não pode estar vazio");

            var produto = new ProdutoModel(req.nome, req.preco, req.qtd);
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return Results.Ok(produto);
        }

        public async Task<IResult> ModificarProdutoAsync(Guid id, ProdutoRequest req)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
            if (produto == null)
                return Results.NotFound("Produto não encontrado");

            if (string.IsNullOrEmpty(req.nome) || req.preco <= 0 || req.qtd < 0)
                return Results.BadRequest("Modificação invalida, veridicar nome,preco ou quantidade estão corretos");
            
            produto.Nome = req.nome;
            produto.Preco = req.preco;
            produto.Estoque = req.qtd;
            await _context.SaveChangesAsync();
            return Results.Ok(produto);
        }

        public async Task<IResult> RemoverProdutoAsync(Guid id)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null)
                return Results.NotFound("Produto não encontrado");

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return Results.Ok(produto);
        }

    }
}
