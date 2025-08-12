using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using minimal_api.Dominio.Entidades;

namespace minimal_api.Infraestrutura.Db
{
    public class DbContexto : DbContext
    {
        private readonly IConfiguration? _config;

        public DbContexto(IConfiguration config)
        {
            _config = config;
        }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options)
        {
        }

        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>().HasData(
                new Administrador
                {
                    Id = 1,
                    Email = "Administrador@test.com",
                    Senha = "123456",
                    Perfil = "Adm"
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                var stringConexao = _config.GetConnectionString("mySql")?.ToString();

                if (!string.IsNullOrEmpty(stringConexao))
                {
                    optionsBuilder.UseMySql(stringConexao, ServerVersion.AutoDetect(stringConexao));
                }
            }
        }

    }
}

