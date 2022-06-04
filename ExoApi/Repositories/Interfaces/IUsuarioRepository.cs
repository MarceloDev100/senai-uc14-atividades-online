using ExoApi.Models;

namespace ExoApi.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Get();  
        Usuario GetBy(int id); 
        void Create(Usuario usuario);
        void Update(int id, Usuario usuario);
        void Delete(int id);
        Usuario Login(string email, string senha);
    }
}