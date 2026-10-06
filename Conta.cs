using System;
using System.Collections.Generic;

class Conta
{
    private static int _contador = 1000;

    public string Numero { get; private set; }
    public decimal Saldo { get; private set; }
    private List<Movimento> _movimentos = new List<Movimento>();

    public Conta(decimal saldoInicial = 0)
    {
        Numero = "PT" + (++_contador);
        Saldo = saldoInicial;
        if (saldoInicial > 0)
            _movimentos.Add(new Movimento("Abertura", saldoInicial));
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0) { Console.WriteLine("  Erro: valor inválido."); return; }
        Saldo += valor;
        _movimentos.Add(new Movimento("Depósito", valor));
        Console.WriteLine($"  Depósito de {valor}€ efetuado. Saldo atual: {Saldo}€");
    }

    public void Levantar(decimal valor)
    {
        if (valor <= 0) { Console.WriteLine("  Erro: valor inválido."); return; }
        if (valor > Saldo) { Console.WriteLine("  Erro: saldo insuficiente."); return; }
        Saldo -= valor;
        _movimentos.Add(new Movimento("Levantamento", valor));
        Console.WriteLine($"  Levantamento de {valor}€ efetuado. Saldo atual: {Saldo}€");
    }

    public void MostrarExtrato()
    {
        Console.WriteLine($"\n  Conta : {Numero}");
        Console.WriteLine($"  Saldo : {Saldo}€");
        Console.WriteLine("  " + new string('-', 42));
        Console.WriteLine($"  {"Data",-12} {"Tipo",-14} {"Valor",8}");
        Console.WriteLine("  " + new string('-', 42));
        foreach (var m in _movimentos)
            Console.WriteLine($"  {m.Data:dd/MM/yyyy}   {m.Tipo,-14} {m.Valor,6}€");
        Console.WriteLine("  " + new string('-', 42));
    }
}
