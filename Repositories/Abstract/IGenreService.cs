using AminesStream.Models.Auth;
using AminesStream.Models.Domain;

namespace AminesStream.Repositories.Abstractions
{
    public interface IGenreService
    {
       bool Add(Genre model);
        
        bool Update(Genre model);

        Genre GetById(int id);

        bool Delete(int id);

        IQueryable<Genre>  List();

    }
}
