using System;
using System.Collections.Generic;

public class CalculadoraInfixada
{
    public static double AvaliarExpressao(string expressao)
    {
        
        Stack<double> valores = new Stack<double>();
        Stack<char> operadores = new Stack<char>();

       
        string[] tokens = expressao.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        foreach (string token in tokens)
        {
           
            if (double.TryParse(token, out double numero))
            {
                valores.Push(numero);
            }
          
            else if (token.Length == 1)
            {
                char op = token[0];
                if (op == '+' || op == '-' || op == '*' || op == '/')
                {
                   
                    while (operadores.Count > 0 && Precedencia(operadores.Peek()) >= Precedencia(op))
                    {
                        double val2 = valores.Pop();
                        double val1 = valores.Pop();
                        char opTopo = operadores.Pop();
                        
                        valores.Push(AplicarOperacao(opTopo, val2, val1));
                    }
                    
                   
                    operadores.Push(op);
                }
            }
        }

       
        while (operadores.Count > 0)
        {
            double val2 = valores.Pop();
            double val1 = valores.Pop();
            char opTopo = operadores.Pop();
            
            valores.Push(AplicarOperacao(opTopo, val2, val1));
        }

       
        return valores.Pop();
    }

   
    private static int Precedencia(char op)
    {
        if (op == '+' || op == '-') 
            return 1;
        
        if (op == '*' || op == '/') 
            return 2;
        
        return 0;
    }

    
    private static double AplicarOperacao(char op, double b, double a)
    {
        switch (op)
        {
            case '+': return a + b;
            case '-': return a - b;
            case '*': return a * b;
            case '/': 
                if (b == 0) throw new DivideByZeroException("Não é possível dividir por zero.");
                return a / b;
            default: return 0;
        }
    }

    public static void Main()
    {
       
        string expressao1 = "3 + 4 * 2";
        Console.WriteLine($"Expressão: {expressao1}");
        Console.WriteLine($"Resultado: {AvaliarExpressao(expressao1)}"); 

        Console.WriteLine("-------------------------");

      
        string expressao2 = "10 - 2 * 3 + 4";
        Console.WriteLine($"Expressão: {expressao2}");
        Console.WriteLine($"Resultado: {AvaliarExpressao(expressao2)}"); 
    }
}
