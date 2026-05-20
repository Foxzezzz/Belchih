using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ChemistryIS.Converters 
{
    public class CategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return new SolidColorBrush(Colors.Gray);

            string category = value.ToString().ToLower();

            switch (category)
            {
                case "щелочные металлы":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF6B6B")); 
                case "щелочноземельные металлы":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9F43")); 
                case "переходные металлы":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#54A0FF")); 
                case "постпереходные металлы":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00D2D3")); 
                case "металлоиды":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#5F27CD")); 
                case "неметаллы":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9FF3")); 
                case "галогены":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FECA57")); 
                case "благородные газы":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1DD1A1")); 
                case "лантаноиды":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#8395A7")); 
                case "актиноиды":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#576574")); 
                default:
                    return new SolidColorBrush(Colors.LightGray);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}