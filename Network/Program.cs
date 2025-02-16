using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Net;
    
public class Network : IEnumerable<KeyValuePair<int, HashSet<int>>>
{
    private Dictionary<int, HashSet<int>> connections;
    public Network(int elementsMax)
    {
        connections = new Dictionary<int, HashSet<int>>();
        for (int i = 1; i <= elementsMax; i++)
        {
            connections[i] = new HashSet<int>();
        }
    }
    public IEnumerator<KeyValuePair<int, HashSet<int>>> GetEnumerator()
    {
        return connections.GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Connect(int num1, int num2)
    {
        if (num1 <= 0 || num2 <= 0)
            throw new ArgumentException("Informe valores maiores que 0");
        connections[num1].Add(num2);
        connections[num2].Add(num1);
    }

    public void Disconnect(int num1, int num2)
    {
        if (num1 <= 0 || num2 <= 0)
            throw new ArgumentException("Informe valores maiores que 0");

        if (!connections.ContainsKey(num1) || !connections.ContainsKey(num2))
            throw new ArgumentException("Elemento inválido.");

        if (connections[num1].Contains(num2))
        {
            connections[num1].Remove(num2);
            connections[num2].Remove(num1);
        }
        
    }
    public bool Query(int num1, int num2)
    {
        return connections.ContainsKey(num1) && connections.ContainsKey(num2) &&  connections[num1].Contains(num2);
    }

    public int levelConnection(int num1, int num2)
    {
        if (!connections.ContainsKey(num1) || !connections.ContainsKey(num2))
            throw new ArgumentException("Elemento inválido.");

        if (num1 == num2) return 0;

        HashSet<int> visited = new HashSet<int>();
        int count = 0;

        if (connections[num1].Contains(num2))
            return count;

        visited.Add(num1);

        List<int> needToVisit = new List<int>(connections[num1]);

        while (needToVisit.Count > 0)
        {
            List<int> nextLevel = new List<int>();
            count++;

            foreach (int node in needToVisit)
            {
                if (!visited.Contains(node))
                {
                    visited.Add(node);

                    if (connections[node].Contains(num2))
                        return count;

                    nextLevel.AddRange(connections[node]);
                }
            }

            needToVisit = nextLevel;
        }

        return 0;
    }

    public static void Main()
    {
        try
        {

            Console.WriteLine("Escreva a quantidade de elementos: ");
            int elementsMax = int.Parse(Console.ReadLine());

            Network network = new Network(elementsMax);

            int option = 0;

            while (option != 5)
            {

                Console.WriteLine("------------------------");
                Console.WriteLine("Conexões: ");
                foreach (var item in network)
                {
                    Console.WriteLine($"Chave: {item.Key}, Valores: {string.Join(", ", item.Value)}");
                }

                Console.WriteLine("------------------------");

                Console.WriteLine("Escolha as opções: ");

                Console.WriteLine("------------------------");

                Console.WriteLine(" 1 - Conectar valores: ");
                Console.WriteLine(" 2 - Desconectar valores: ");
                Console.WriteLine(" 3 - Checar conexões: ");
                Console.WriteLine(" 4 - Ver quantas conexões: ");
                Console.WriteLine(" 5 - Sair: ");

                Console.WriteLine("                          ");
                Console.WriteLine("Opção: ");
                option = int.Parse(Console.ReadLine());

                if (option == 5) break;

                Console.WriteLine("------------------------");

                Console.WriteLine("Digite o primeiro número: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o segundo número: ");
                int num2 = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        network.Connect(num1, num2);
                        break;
                    case 2:
                        network.Disconnect(num1, num2);
                        break;
                    case 3:
                        if (!network.Query(num1, num2))
                        {
                            Console.WriteLine("Não existe conexão direta entre esses valores.");
                        }
                        else
                        {
                            Console.WriteLine("Existe conexão direta entre esses valores.");
                        }
                        break;
                    case 4:
                        int quantity = network.levelConnection(num1, num2);
                        Console.WriteLine($"Existem {quantity} conexões.");
                        break;

                }

            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Digite apenas números válidos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}