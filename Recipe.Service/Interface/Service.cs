using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Service.Interface
{
    public interface Service<T, PK>
    {
        T Create(T type);
        T Retrieve(PK id);
        List<T> RetrieveAll();
        T Update(T type);
        void Delete(PK id);
    }
}
