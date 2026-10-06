using System;

class Movimento
{
    public DateTime Data { get; private set; }
    public string Tipo { get; private set; }
    public decimal Valor { get; private set; }

    public Movimento(string tipo, decimal valor)
    {
        Data = DateTime.Now;
        Tipo = tipo;
        Valor = valor;
    }
}
