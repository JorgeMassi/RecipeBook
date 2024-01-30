using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public User? RecipeWriter { get; set; }
        public Rating? Rating { get; set; }
        public Recipe? Recipe { get; set; }

    }
}
