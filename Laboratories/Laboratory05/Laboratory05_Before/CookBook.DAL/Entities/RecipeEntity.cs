﻿using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.DAL.Enums;

namespace CookBook.DAL.Entities
{
    public class RecipeEntity : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public FoodType FoodType { get; set; }
        public virtual ICollection<IngredientAmountEntity> Ingredients { get; } = new List<IngredientAmountEntity>();

        public static IEqualityComparer<RecipeEntity> RecipeEntityComparer { get; } =
            new RecipeEntityEqualityComparer();

        public static IEqualityComparer<RecipeEntity> WithoutIngredientsComparer { get; } =
            new WithoutIngredientsEqualityComparer();

        private sealed class RecipeEntityEqualityComparer : IEqualityComparer<RecipeEntity>
        {
            public bool Equals(RecipeEntity x, RecipeEntity y)
            {
                if (ReferenceEquals(x, y)) return true;

                if (ReferenceEquals(x, null)) return false;

                if (ReferenceEquals(y, null)) return false;

                if (x.GetType() != y.GetType()) return false;

                return x.Id.Equals(y.Id) &&
                       string.Equals(x.Name, y.Name) &&
                       string.Equals(x.Description, y.Description) &&
                       x.Duration.Equals(y.Duration) &&
                       x.FoodType == y.FoodType &&
                       x.Ingredients.OrderBy(amount => amount.Id).SequenceEqual(
                           y.Ingredients.OrderBy(amount => amount.Id), IngredientAmountEntity.IngredientAmountComparer);
            }

            public int GetHashCode(RecipeEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Description.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Duration.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) obj.FoodType;
                    hashCode = (hashCode * 397) ^ (obj.Ingredients != null ? obj.Ingredients.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }

        private sealed class WithoutIngredientsEqualityComparer : IEqualityComparer<RecipeEntity>
        {
            public bool Equals(RecipeEntity x, RecipeEntity y)
            {
                if (ReferenceEquals(x, y)) return true;

                if (ReferenceEquals(x, null)) return false;

                if (ReferenceEquals(y, null)) return false;

                if (x.GetType() != y.GetType()) return false;

                return x.Id.Equals(y.Id) && string.Equals(x.Name, y.Name) &&
                       string.Equals(x.Description, y.Description) && x.Duration.Equals(y.Duration) &&
                       x.FoodType == y.FoodType;
            }

            public int GetHashCode(RecipeEntity obj)
            {
                unchecked
                {
                    var hashCode = obj.Id.GetHashCode();
                    hashCode = (hashCode * 397) ^ (obj.Name != null ? obj.Name.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ (obj.Description != null ? obj.Description.GetHashCode() : 0);
                    hashCode = (hashCode * 397) ^ obj.Duration.GetHashCode();
                    hashCode = (hashCode * 397) ^ (int) obj.FoodType;
                    return hashCode;
                }
            }
        }
    }
}