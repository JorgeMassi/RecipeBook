using RecipeBook.Model;
using RecipeBook.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RecipeBook.Service
{
    public class MeasureService : IMeasureService
    {
        private readonly IMeasureRepository _measureRepository;

        public MeasureService(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public Measure Create(Measure measure)
        {
            return _measureRepository.Create(measure);
        }

        public void Delete(int id)
        {
            _measureRepository.Delete(id);
        }

        public Measure Retrieve(int id)
        {
            return _measureRepository.Retrieve(id);
        }

        public List<Measure> RetrieveAll()
        {
            return _measureRepository.RetrieveAll();
        }

        public Measure Update(Measure measure)
        {
            return _measureRepository.Update(measure);  
        }
    }
}
