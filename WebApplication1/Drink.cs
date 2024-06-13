// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;

// namespace WebApplication1
// {
//     public class Ingredient
//     {
//         public string Name { get; set; } = null!;
//         public string Amount { get; set; } = null!;
//     }

//     public class Review
//     {
//   public int Rating { get; set; }
//         public string Comment { get; set; } = null!;
//     }

//     public class Drink
//     {
//         public Guid Id { get; set; } = Guid.NewGuid(); 
//         public string Name { get; set; } 
//         public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>(); 
//         public string RecipeText { get; set; } 
//         public string ImgUrl { get; set; } 
//         public List<Review> Reviews { get; set; } = new List<Review>(); 
//         public List<string> Categories { get; set; } = new List<string>(); 

//         public Drink(string name, string recipeText, string imgUrl, List<Ingredient> ingredients, List<string> categories)
//         {
//             Name = name;
//             RecipeText = recipeText;
//             ImgUrl = imgUrl;
//             Ingredients = ingredients;
//             Categories = categories;
//         }
//     }
// }
