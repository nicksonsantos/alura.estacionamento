using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class TipoVeiculoTeste : IDisposable
    {
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;

        public TipoVeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            // Arrange

            // Act

            // Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact]
        public void TestaTipoVeiculoMotocicleta()
        {
            // Arrange
            var veiculo = new Veiculo();
            // Act
            veiculo.Tipo = TipoVeiculo.Motocicleta;
            // Assert
            Assert.Equal(TipoVeiculo.Motocicleta, veiculo.Tipo);
        }
        public void Dispose()
        {
            Output.WriteLine("Execução do Cleanup: Limpando os objetos.");
        }
    }
}