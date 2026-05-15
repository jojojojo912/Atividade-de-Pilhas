using System;
using System.Collections.Generic;

public class PilhaOrdenada
{
    public static Stack<int> Ordenar(Stack<int> pilhaOriginal)
    {
        Stack<int> pilhaAuxiliar = new Stack<int>();

        
        while (pilhaOriginal.Count > 0)
        {
            int temp = pilhaOriginal.Pop();

            
            while (pilhaAuxiliar.Count > 0 && pilhaAuxiliar.Peek() < temp)
            {
                pilhaOriginal.Push(pilhaAuxiliar.Pop());
            }

            
            pilhaAuxiliar.Push(temp);
        }

       
        return pilhaAuxiliar;
    }

    
    public static void Main()
    {
        Stack<int> pilha = new Stack<int>();
        
        
        pilha.Push(34);
        pilha.Push(3);
        pilha.Push(31);
        pilha.Push(98);
        pilha.Push(92);
        pilha.Push(23);

        Console.WriteLine("Ordenando a pilha...");
        Stack<int> pilhaOrdenada = Ordenar(pilha);

        Console.WriteLine("Pilha ordenada (topo para a base):");
        while (pilhaOrdenada.Count > 0)
        {
            Console.WriteLine(pilhaOrdenada.Pop());
        }
        
    }
}