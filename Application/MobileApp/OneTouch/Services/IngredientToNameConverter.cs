using System;
using System.Globalization;
using MobileApp.FürmichbistdueinfachkeinModel;
using Xamarin.Forms;

namespace OneTouch.Services
{
    public class IngredientToNameConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Ingredient ingredient = (Ingredient)value;
            return ingredient.Name;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Ingredient ingredient = new Ingredient { Name = (string)value };
            return ingredient;
        }
    }
}
