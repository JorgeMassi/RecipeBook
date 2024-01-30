﻿using RecipeBook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Repository
{
    public interface IRatingRepository
    {
        Rating Create(Rating rating);
        Rating Update(Rating rating);
        void Delete(int id);
        Rating Retrieve(int id);
        List<Rating> RetrieveAll();
        
	}
}
