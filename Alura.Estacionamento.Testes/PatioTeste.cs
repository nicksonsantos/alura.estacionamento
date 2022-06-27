using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Testes
{
    public class PatioTeste
    {
        private Patio estacionamento;
        private Veiculo veiculo;

        public PatioTeste()
        {
            estacionamento = new Patio();
            veiculo = new Veiculo();
        }

        [Fact]
        public void ValidaFaturamentoDoEstacionamentoComUmVeiculo()
        {
            // Arrange
            veiculo.Proprietario = "Nickson Endlich";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Corolla";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Neymar da Silva Santos Júnior", "ASD-1498", "Preto", "Gol")]
        [InlineData("Cristiano Ronaldo dos Santos Aveiro", "POL-9242", "Cinza", "Fusca")]
        [InlineData("Lionel Andrés Messi Cuccittini", "GDR-6524", "Azul", "Opala")]
        public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;         

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Neymar da Silva Santos Júnior", "ASD-1498", "Preto", "Gol")]
        public void TestaLocalizaVeiculoNoPatioComBaseNaPlaca(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            // Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void TestaAlterarDadosDoProprioVeiculo()
        {
            // Arrange
            veiculo.Proprietario = "José Silva";
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto"; // Alterado
            veiculoAlterado.Modelo = "Opala";
            // Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            // Assert
            Assert.Equal(veiculoAlterado.Cor, alterado.Cor);
        }

        
    }
}
