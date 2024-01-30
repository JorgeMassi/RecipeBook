using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Model
{
    public class Favourite
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public Recipe? Recipe { get; set; }

    }

}
