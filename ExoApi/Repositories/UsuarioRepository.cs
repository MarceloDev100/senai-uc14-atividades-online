using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories.Interfaces
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ProjetoContext _context;

        public UsuarioRepository(ProjetoContext context)
        {
            _context = context;
        }

         public List<Usuario> Get()
        {
            var usuarios = _context.Usuarios.ToList();

            return usuarios;
        }

        public Usuario GetBy(int id)
        {
            var usuario = _context.Usuarios.Find(id);

            return usuario;
        }
        
        public void Create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(int id, Usuario usuario)
        {
            var usuarioBanco = GetBy(id);

            usuarioBanco.Email = usuario.Email ?? usuarioBanco.Email;
            usuarioBanco.Senha = usuario.Senha ?? usuarioBanco.Senha;
            usuarioBanco.Tipo = usuario.Tipo ?? usuarioBanco.Tipo;

            _context.Usuarios.Update(usuarioBanco);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
           var usuario = GetBy(id);

           _context.Usuarios.Remove(usuario);
           _context.SaveChanges();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }
    }
}