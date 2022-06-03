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
            _context.Add(projeto);
            _context.SaveChanges();
        }

        public void Update(int id, Projeto projeto)
        {
            var projetoBanco = GetBy(id);
      
            projetoBanco.Titulo = projeto.Titulo;
            projetoBanco.Status = projeto.Status;
            projetoBanco.DataInicio = projeto.DataInicio;
            projetoBanco.Tecnologia = projeto.Tecnologia;
            projetoBanco.Requisito = projeto.Requisito;
            projetoBanco.Area = projeto.Area;

            _context.Update(projetoBanco);
            _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var projeto = GetBy(id);

            if(projeto != null)
            {
              _context.Projetos.Remove(projeto);
              _context.SaveChanges();
            }
        }
    }
}
