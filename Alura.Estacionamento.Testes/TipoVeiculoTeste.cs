using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Testes
{
    public class TipoVeiculoTeste
    {
        // Arrange
        // Act
        // Assert

        [Fact]
        public void TestaTipoVeiculo()
        {
            // Arrange
            var veiculo = new Veiculo();
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
    }
}