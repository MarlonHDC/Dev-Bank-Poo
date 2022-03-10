namespace Bank
{
    public class Conta
    {
        // Atributos sempre privados (encapsulamento)
        private TipoConta TipoConta {get; set; }

        private double Saldo {get; set; }

        private double Credito {get; set; }

        public String Nome { get; set; }

        // Método construtor. Sempre com o nome da classe.
        public Conta(TipoConta tipoConta, double saldo, double credito, String nome)
        {
            this.TipoConta = tipoConta;
            this.Credito = credito;
            this.Saldo = saldo;
            this.Nome = nome;
            
        }

        public bool Sacar (double valorSaque)
        {
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito * -1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

            return true;
        }

        public void Depositar(double valorDeposito) {
            this.Saldo += valorDeposito; // Equivalente a:  "this.Saldo = this.Saldo + valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }

        // Transferência
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = " ";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;
        }

    }
    
}