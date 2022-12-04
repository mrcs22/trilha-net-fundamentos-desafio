using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Regex formatoPlacaAntiga = new Regex("^[a-zA-Z]{3}-[0-9]{4}$");
            Regex formatoPlacaMercosul = new Regex("^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
          
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placaVeiculo = Console.ReadLine();

            bool ehPlacaAntiga = formatoPlacaAntiga.Match(placaVeiculo).Success;
            bool ehPlacaMercosul = formatoPlacaMercosul.Match(placaVeiculo).Success;

            if(!ehPlacaAntiga && !ehPlacaMercosul){
                Console.WriteLine("Placa inválida!");
                return; 
            }

            veiculos.Add(placaVeiculo);
            Console.WriteLine("Veículo adicionado! ^^");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = this.precoInicial + this.precoPorHora * horas; 

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                foreach (string placa in veiculos)
                {
                    Console.WriteLine(placa);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
