using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface Repository<T, PK>
    {

        T Create(T type);
        T Retrive(PK id);
        List<T> GetAll();
        T Update(T type);
        void Delete(PK id);
    }
}
