using System.Collections.Generic;
using System.Linq;
using CookBook.BL.Factories;
using CookBook.BL.Models;
using CookBook.BL.Repositories;

namespace CookBook.App.ViewModels
{
    internal class IngredientListViewModel
    {
        private readonly IIngredientRepository repository = new IngredientRepository(new DbContextFactory());

        public List<IngredientListModel> Ingredients { get; set; }

        public void Load()
        {
            Ingredients = repository.GetAll()
                .ToList();
        }
    }
}