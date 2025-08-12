using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorTest
    {
        [TestMethod]
        public void TestarGetSetProprieddades()
        {
            //arrange
            var adm = new Administrador();

            //Act
            adm.Id = 1;
            adm.Email = "teste@teste.com";
            adm.Senha = "Senha";
            adm.Perfil = "Adm";

            //Assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("teste@teste.com", adm.Email);
            Assert.AreEqual("Senha", adm.Senha);
            Assert.AreEqual("Adm", adm.Perfil);
        }
    }
}
