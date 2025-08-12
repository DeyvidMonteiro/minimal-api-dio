using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class VeiculosTest
    {
        [TestMethod]
        public void TestarGetSetProprieddades()
        {
            var veiculo = new Veiculo();

            veiculo.Id = 1;
            veiculo.Nome = "Celta";
            veiculo.Marca = "Chevorlet";
            veiculo.Ano = "2015";

            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Celta", veiculo.Nome);
            Assert.AreEqual("Chevorlet", veiculo.Marca);
            Assert.AreEqual("2015", veiculo.Ano);
        }
    }
}
