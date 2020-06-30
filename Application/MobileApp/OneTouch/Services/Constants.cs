using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using MobileApp.FürmichbistdueinfachkeinModel;

namespace MobileApp.Services
{
    /// <summary>
    /// Diese Datei enthält Konstanten, die über alle Klassen hinweg verfügbar sein sollen
    /// </summary>
    public enum ReturnCode
    {
        success,
        wrongPassword,
        usernameNotFound,
        fatalError,
        wrongCredentials,
        orderError,
        countError
    }

    public class IngredientSelection
    {
        public List<Ingredient> GetIngredientSelection ()
        {
            var Ingredients = new List<Ingredient>()
            {
            //Alkohol
            new Ingredient{Name = "Wodka"}, new Ingredient{Name = "Gin"}, new Ingredient{Name = "Whiskey"},
                new Ingredient{Name = "Aperol"}, new Ingredient{Name = "Sekt"}, new Ingredient{Name = "Jaegermeister"},
            //Softdrinks
            new Ingredient{Name = "Cola"}, new Ingredient{Name = "Fanta"}, new Ingredient{Name = "Sprite"},
            new Ingredient{Name = "Tonic Water"},
            //Säfte
            new Ingredient{Name = "Orangensaft"}, new Ingredient{Name = "Cranberrysaft"}, new Ingredient{Name = "Limonensaft"}, new Ingredient {Name ="Grapefruitsaft"},
            
            //anderes
            new Ingredient{Name = "Wasser"}, new Ingredient{Name = "Sirup"}
            };
            return Ingredients;
        }

    }
}
 