using System;

public class Produto
{
    public int CodigoProduto;
    public string NomeProduto;
    public double Preco;
    public int QuantidadeEstoque;

    public void ReceberDados()
    {
        Console.Write("Código do produto: ");
        CodigoProduto = int.Parse(Console.ReadLine());
        Console.Write("Nome do produto: ");
        NomeProduto = Console.ReadLine();
        Console.Write("Preço: ");
        Preco = double.Parse(Console.ReadLine());
        Console.Write("Quantidade inicial: ");
        QuantidadeEstoque = int.Parse(Console.ReadLine());
    }

    public void AdicionarEstoque()
    {
        Console.Write("Quantidade a adicionar: ");
        int qtd = int.Parse(Console.ReadLine());
        QuantidadeEstoque += qtd;
    }

    public void RemoverEstoque()
    {
        Console.Write("Quantidade a remover: ");
        int qtd = int.Parse(Console.ReadLine());
        if (qtd <= QuantidadeEstoque)
            QuantidadeEstoque -= qtd;
        else
            Console.WriteLine("Estoque insuficiente.");
    }

    public void MostrarProduto()
    {
        Console.WriteLine($"\n[Produto] Código: {CodigoProduto} | Nome: {NomeProduto} | Preço: R${Preco:F2} | Estoque: {QuantidadeEstoque}");
    }
}

public class ProgramEx3
{
    public static void Main()
    {
        Produto p = new Produto();
        p.ReceberDados();
        p.MostrarProduto();
        p.AdicionarEstoque();
        p.MostrarProduto();
        p.RemoverEstoque();
        p.MostrarProduto();
    }
}
