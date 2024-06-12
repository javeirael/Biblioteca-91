using Domain.Entities;

namespace WebApi91.Services
{
    public interface IAutoreService
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> CreateAutores(Autor i);
        public Task<Response<Autor>> UpdateAutor(int PkAutor, Autor i);
        public Task<Response<Autor>> BorrarAutores(int PkAutor);
    }
}
