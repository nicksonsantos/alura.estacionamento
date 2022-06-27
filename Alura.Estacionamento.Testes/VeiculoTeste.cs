using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTeste : IDisposable
    {
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;

        public VeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
        }

        [Fact]
        public void TestaVeiculoAcelerarComParametro10()
        {
            // Arrange

            // Act
            veiculo.Acelerar(10);
            // Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrearComParametro10()
        {
            // Arrange

            // Act
            veiculo.Frear(10);
            // Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Theory]
        [ClassData(typeof(Veiculo))]
        public void TestaVeiculoClass(Veiculo modelo)
        {
            // Arrange

            // Act
            veiculo.Acelerar(10);
            modelo.Acelerar(10);

            // Assert
            Assert.Equal(modelo.VelocidadeAtual, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Teste ainda não implementado. Ignorar")]
        public void ValidaNomeProprietarioDoVeiculo()
        {

        }

        [Fact]
        public void FichaDeInformacaoDoVeiculo()
        {
            // Arrange
            veiculo.Proprietario = "Carlos Silva";
            veiculo.Placa = "ZAP-7419";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Variante";

            // Act
            string dados = veiculo.ToString();

            // Assert
            Assert.Contains("Tipo do Veículo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            // Arrange
            string nomeProprietarioErrado = "Ab";

            // Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Proprietario = nomeProprietarioErrado
            );

        }

        [Fact]
        public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            // Arrange
            string placaErrada = "ASDF8888";

            // Act
            var mensagem = Assert.Throws<FormatException>(
                () => new Veiculo().Placa = placaErrada);

            // Assert
            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);

        }

        [Fact]
        public void TestaUltimosCaracteresPlacaVeiculoComoNumeros()
        {
            // Arrange
            string placaFormatoErrado = "ASD-995U";

            // Assert
            Assert.Throws<FormatException>(
                // Act
                () => new Veiculo().Placa = placaFormatoErrado
            );

        }

        public void Dispose()
        {
            Output.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}