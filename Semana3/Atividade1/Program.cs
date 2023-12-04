using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<(int codigo, string nome, int quantidade, double preco)> estoque = new List<(int, string, int, double)>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Cadastrar produto");
            Console.WriteLine("2. Buscar produto por código");
            Console.WriteLine("3. Atualizar quantidade em estoque");
            Console.WriteLine("4. Gerar relatórios");
            Console.WriteLine("0. Sair");

            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    BuscarProdutoPorCodigo();
                    break;
                case "3":
                    AtualizarQuantidade();
                    break;
                case "4":
                    GerarRelatorios();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço unitário: ");
            double preco = double.Parse(Console.ReadLine());

            estoque.Add((codigo, nome, quantidade, preco));

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro ao cadastrar produto. Certifique-se de fornecer valores válidos.");
        }
    }

    static void BuscarProdutoPorCodigo()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.codigo == codigo);

            if (produto == default)
            {
                throw new ProdutoNaoEncontradoException();
            }

            Console.WriteLine($"Produto encontrado: {produto.codigo} - {produto.nome}, Quantidade: {produto.quantidade}, Preço: {produto.preco:C}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro ao buscar produto. Certifique-se de fornecer um código válido.");
        }
        catch (ProdutoNaoEncontradoException)
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    static void AtualizarQuantidade()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.FirstOrDefault(p => p.codigo == codigo);

            if (produto == default)
            {
                throw new ProdutoNaoEncontradoException();
            }

            Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
            int quantidadeAtualizacao = int.Parse(Console.ReadLine());

            if (produto.quantidade + quantidadeAtualizacao < 0)
            {
                throw new QuantidadeInsuficienteException();
            }

            produto.quantidade += quantidadeAtualizacao;

            Console.WriteLine("Quantidade atualizada com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro ao atualizar quantidade. Certifique-se de fornecer valores válidos.");
        }
        catch (ProdutoNaoEncontradoException)
        {
            Console.WriteLine("Produto não encontrado!");
        }
        catch (QuantidadeInsuficienteException)
        {
            Console.WriteLine("Quantidade insuficiente em estoque para realizar a operação.");
        }
    }

    static void GerarRelatorios()
    {
        Console.Write("Digite o limite de quantidade para o relatório de estoque baixo: ");
        int limiteEstoqueBaixo = int.Parse(Console.ReadLine());

        var produtosEstoqueBaixo = estoque.Where(p => p.quantidade < limiteEstoqueBaixo);
        Console.WriteLine("Relatório de produtos com quantidade em estoque abaixo do limite:");
        foreach (var produto in produtosEstoqueBaixo)
        {
            Console.WriteLine($"{produto.codigo} - {produto.nome}, Quantidade: {produto.quantidade}, Preço: {produto.preco:C}");
        }

        Console.Write("Digite o valor mínimo para o relatório de produtos com valor entre: ");
        double minValor = double.Parse(Console.ReadLine());

        Console.Write("Digite o valor máximo: ");
        double maxValor = double.Parse(Console.ReadLine());

        var produtosValorEntre = estoque.Where(p => p.preco >= minValor && p.preco <= maxValor);
        Console.WriteLine("Relatório de produtos com valor entre o mínimo e o máximo:");
        foreach (var produto in produtosValorEntre)
        {
            Console.WriteLine($"{produto.codigo} - {produto.nome}, Quantidade: {produto.quantidade}, Preço: {produto.preco:C}");
        }

        double valorTotalEstoque = estoque.Sum(p => p.quantidade * p.preco);
        Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");
    }
}

class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException() : base("Produto não encontrado!") { }
}

class QuantidadeInsuficienteException : Exception
{
    public QuantidadeInsuficienteException() : base("Quantidade insuficiente em estoque para realizar a operação.") { }
}
