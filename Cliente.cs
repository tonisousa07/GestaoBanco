using System.Collections.Generic;

class Cliente
{
    public string Nome { get; private set; }
    public string NIF { get; private set; }
    public List<Conta> Contas { get; private set; } = new List<Conta>();

    public Cliente(string nome, string nif)
    {
        Nome = nome;
        NIF = nif;
    }

    public Conta AbrirConta(decimal saldoInicial = 0)
    {
        var conta = new Conta(saldoInicial);
        Contas.Add(conta);
        return conta;
    }
}
 