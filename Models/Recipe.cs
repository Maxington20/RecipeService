﻿namespace RecipeService.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Directions { get; set; }

        public Guid UserId { get; set; }
    }
}
