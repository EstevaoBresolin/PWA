namespace PWA2.Models
{
    public class Conta
    {

        public double Saldo { get; set; }
        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            Saldo -= valor;
        }
    }
}

