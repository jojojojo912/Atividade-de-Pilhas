using System;
using System.Collections.Generic;

public class BrowserHistory
{
    private Stack<string> historico = new Stack<string>();
    private Stack<string> avancar = new Stack<string>();

    public void Visitar(string url)
    {
        historico.Push(url);
        avancar.Clear(); 
        Console.WriteLine($"Visitou: {url}");
    }

   
    public void Voltar()
    {
        if (historico.Count > 1) 
        {
            string paginaAtual = historico.Pop();
            avancar.Push(paginaAtual); 
            Console.WriteLine($"Voltou para: {historico.Peek()}");
        }
        else
        {
            Console.WriteLine("Não há páginas anteriores para voltar.");
        }
    }

   
    public void Avancar()
    {
        if (avancar.Count > 0)
        {
            string paginaSeguinte = avancar.Pop();
            historico.Push(paginaSeguinte);
            Console.WriteLine($"Avançou para: {historico.Peek()}");
        }
        else
        {
            Console.WriteLine("Não há páginas seguintes para avançar.");
        }
    }

   
    public void ExibirPaginaAtual()
    {
        if (historico.Count > 0)
        {
            Console.WriteLine($"Página atual: {historico.Peek()}");
        }
        else
        {
            Console.WriteLine("Nenhuma página aberta no momento.");
        }
    }
}


public class Program
{
    public static void Main()
    {
        BrowserHistory browser = new BrowserHistory();
        
        browser.Visitar("google.com");
        browser.Visitar("github.com");
        browser.Visitar("stackoverflow.com");
        
        browser.ExibirPaginaAtual(); 
        browser.Voltar();            
        browser.Voltar();            
        browser.Avancar();           
    }
}