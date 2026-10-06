using System;
using System.Collections.Generic;

class Program
{
    static List<Cliente> clientes = new List<Cliente>();

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool sair = false;
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("╔════════════════════════════════╗");
            Console.WriteLine("║      GESTÃO BANCÁRIA           ║");
            Console.WriteLine("╠════════════════════════════════╣");
            Console.WriteLine("║  1  Criar cliente              ║");
            Console.WriteLine("║  2  Abrir conta                ║");
            Console.WriteLine("║  3  Depositar                  ║");
            Console.WriteLine("║  4  Levantar                   ║");
            Console.WriteLine("║  5  Ver extrato                ║");
            Console.WriteLine("║  0  Sair                       ║");
            Console.WriteLine("╚════════════════════════════════╝");
            Console.Write("\n  Opção: ");
            string op = Console.ReadLine();

            Console.Clear();

            switch (op)
            {
                case "1": CriarCliente(); break;
                case "2": AbrirConta(); break;
                case "3": Depositar(); break;
                case "4": Levantar(); break;
                case "5": VerExtrato(); break;
                case "0": sair = true; Console.WriteLine("\n  Até logo!\n"); break;
                default:  Console.WriteLine("  Opção inválida."); break;
            }

            if (!sair)
            {
                Console.Write("\n  Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }
    }

    static void CriarCliente()
    {
        Console.WriteLine("  ── Criar Cliente ──\n");
        Console.Write("  Nome : "); string nome = Console.ReadLine();
        Console.Write("  NIF  : "); string nif  = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(nif))
        { Console.WriteLine("\n  Erro: preencha todos os campos."); return; }

        clientes.Add(new Cliente(nome, nif));
        Console.WriteLine("\n  Cliente criado com sucesso.");
    }

    static void AbrirConta()
    {
        Console.WriteLine("  ── Abrir Conta ──\n");
        var c = EscolherCliente();
        if (c == null) return;

        Console.Write("\n  Saldo inicial (€): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal saldo) || saldo < 0)
        { Console.WriteLine("\n  Erro: valor inválido."); return; }

        var conta = c.AbrirConta(saldo);
        Console.WriteLine($"\n  Conta {conta.Numero} criada com {saldo}€.");
    }

    static void Depositar()
    {
        Console.WriteLine("  ── Depósito ──\n");
        var conta = EscolherConta();
        if (conta == null) return;

        Console.Write("\n  Valor a depositar (€): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal v))
        { Console.WriteLine("\n  Erro: valor inválido."); return; }

        conta.Depositar(v);
    }

    static void Levantar()
    {
        Console.WriteLine("  ── Levantamento ──\n");
        var conta = EscolherConta();
        if (conta == null) return;

        Console.Write("\n  Valor a levantar (€): ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal v))
        { Console.WriteLine("\n  Erro: valor inválido."); return; }

        conta.Levantar(v);
    }

    static void VerExtrato()
    {
        Console.WriteLine("  ── Extrato ──\n");
        EscolherConta()?.MostrarExtrato();
    }

    static Cliente EscolherCliente()
    {
        if (clientes.Count == 0) { Console.WriteLine("  Sem clientes registados."); return null; }
        for (int i = 0; i < clientes.Count; i++)
            Console.WriteLine($"  {i + 1}.  {clientes[i].Nome}  (NIF: {clientes[i].NIF})");
        Console.Write("\n  Escolha cliente: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= clientes.Count)
            return clientes[idx - 1];
        Console.WriteLine("\n  Seleção inválida.");
        return null;
    }

    static Conta EscolherConta()
    {
        var c = EscolherCliente();
        if (c == null) return null;
        if (c.Contas.Count == 0) { Console.WriteLine("\n  Este cliente não tem contas."); return null; }
        Console.WriteLine("\n  Contas:");
        for (int i = 0; i < c.Contas.Count; i++)
            Console.WriteLine($"  {i + 1}.  {c.Contas[i].Numero}  |  Saldo: {c.Contas[i].Saldo}€");
        Console.Write("\n  Escolha conta: ");
        if (int.TryParse(Console.ReadLine(), out int idx) && idx >= 1 && idx <= c.Contas.Count)
            return c.Contas[idx - 1];
        Console.WriteLine("\n  Seleção inválida.");
        return null;
    }
}
