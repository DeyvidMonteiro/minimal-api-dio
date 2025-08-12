using minimal_api.Dominio.DTOs;
using minimal_api.Dominio.Entidades;
using minimal_api.Infraestrutura.Db;
using minimal_api.Infraestrutura.Interfaces;

namespace minimal_api.Dominio.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly DbContexto _contexto;

        public AdministradorServico(DbContexto contexto)
        {
            _contexto = contexto;
        }

        public Administrador? Incluir(Administrador administrador)
        {
            _contexto.Administrador.Add(administrador);
            _contexto.SaveChanges();

            return administrador;
        }

        public List<Administrador>? Todos(int? pagina)
        {
            var query = _contexto.Administrador.AsQueryable();

            int itemPorPagina = 10;

            if (pagina != null)
            {
                query = query.Skip(((int)pagina - 1) * itemPorPagina).Take(itemPorPagina);
            }

            return query.ToList();
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            var adm = _contexto.Administrador.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();
            return adm;
        }

        public Administrador? BuscaPorId(int id)
        {
            return _contexto.Administrador.FirstOrDefault(v => v.Id == id);
        }
    }
}
