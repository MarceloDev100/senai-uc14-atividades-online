using ExoApi.Contexts;
using ExoApi.Models;
using ExoApi.Repositories.Interfaces;

namespace ExoApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly ProjetoContext _context;

        public ProjetoRepository(ProjetoContext context)
        {
            _context = context;
        }

        public List<Projeto> Get()
        {
            var projetos = _context.Projetos.ToList();
            return projetos;
        }

        public Projeto GetBy(int id)
        {
            var projeto = _context.Projetos.Find(id);
            return projeto;
        }

         public void Create(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public void Update(int id, Projeto projeto)
        {
            var projetoBanco = GetBy(id);
      
            projetoBanco.Titulo = projeto.Titulo ?? projetoBanco.Titulo;
            projetoBanco.Status = string.IsNullOrEmpty(projeto.Status.ToString()) ?
                                  projetoBanco.Status : projeto.Status;

            projetoBanco.DataInicio = projeto.DataInicio != new DateTime() ? 
                                      projeto.DataInicio : projetoBanco.DataInicio;

            projetoBanco.Tecnologia = projeto.Tecnologia ?? projetoBanco.Tecnologia;
            projetoBanco.Requisito  = projeto.Requisito ?? projetoBanco.Requisito;
            projetoBanco.Area       = projeto.Area ?? projetoBanco.Area;

            _context.Projetos.Update(projetoBanco);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var projeto = GetBy(id);

            _context.Projetos.Remove(projeto);
            _context.SaveChanges();
            
        }
    }
}
