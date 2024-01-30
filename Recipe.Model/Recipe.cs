using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Model
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public User? RecipeWriter { get; set; }
        public Category? Category { get; set; }
        public Difficulty? Difficulty { get; set; }
        public int? PreparationTime { get; set; }
        public string? PreparationMethod { get; set; }
        public List<IngredientLine>? IngredientLine { get; set; }
        public bool IsApproved { get; set; }
    }
}
