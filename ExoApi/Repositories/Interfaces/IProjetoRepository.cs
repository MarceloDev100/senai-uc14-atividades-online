using ExoApi.Models;

namespace ExoApi.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
         List<Projeto> Get();  
         Projeto GetBy(int id); 
         void Create(Projeto projeto);
         void Update(int id, Projeto projeto);
         void Delete(int id);
    }
}