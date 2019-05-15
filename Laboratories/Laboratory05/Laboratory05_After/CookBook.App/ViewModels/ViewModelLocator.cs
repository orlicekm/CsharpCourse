﻿using CookBook.App.Services;
using CookBook.BL.Factories;
using CookBook.BL.Repositories;
using CookBook.BL.Services;

namespace CookBook.App.ViewModels
{
    public class ViewModelLocator
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IMediator mediator;
        private readonly IMessageBoxService messageBoxService;

        public ViewModelLocator()
        {
            mediator = new Mediator();
            dbContextFactory = new DbContextFactory();
            ingredientRepository = new IngredientRepository(dbContextFactory);
            messageBoxService = new MessageBoxService();
        }

        public IngredientListViewModel IngredientListViewModel =>
            new IngredientListViewModel(ingredientRepository, mediator);

        public IngredientDetailViewModel IngredientDetailViewModel =>
            new IngredientDetailViewModel(ingredientRepository, messageBoxService, mediator);
    }
}