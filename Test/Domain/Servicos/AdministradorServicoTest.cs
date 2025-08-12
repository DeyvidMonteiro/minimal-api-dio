using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTest
{
    [TestMethod]
    public void TestsAdm()
    {
        //Arrange
        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "Senha";
        adm.Perfil = "Adm";

        var _contexto = CriarContextoTeste();
        var administradorServico = new AdministradorServico(_contexto);

        var loginDTO = new LoginDTO
        {
            Email = adm.Email,
            Senha = adm.Senha,
        };

        //Act
        administradorServico.Incluir(adm);
        var admId = administradorServico.BuscaPorId(adm.Id);
        var admLogin = administradorServico.Login(loginDTO);

        //Assert
        Assert.AreEqual(1, administradorServico.Todos(1)?.Count ?? 0);
        Assert.AreEqual(1, admId?.Id);
        Assert.IsNotNull(admLogin);
        Assert.AreEqual(loginDTO.Email, admLogin.Email);


    }

    private DbContexto CriarContextoTeste()
    {
        var opt = new DbContextOptionsBuilder<DbContexto>()
            .UseInMemoryDatabase(databaseName: "TestDataBase")
            .Options;

        return new DbContexto(opt);
    }
}
