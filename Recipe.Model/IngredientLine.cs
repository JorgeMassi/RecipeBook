using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Model
{
    public class IngredientLine
    {
        public int Id { get; set; }
        public double? Qtd { get; set; }
        public Recipe? Recipe { get; set; }
        public Ingredient? Ingredient { get; set; }
        public Measure? Measure { get; set; }

    }
}
