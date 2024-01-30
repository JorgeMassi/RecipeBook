using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IMeasureRepository
    {
        Measure Create(Measure measure);
        Measure Update(Measure measure);
        void Delete(int id);
        Measure Retrieve(int id);
        List<Measure> RetrieveAll();
    }
}
