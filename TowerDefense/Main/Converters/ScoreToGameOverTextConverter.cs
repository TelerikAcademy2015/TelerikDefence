﻿namespace TowerDefense.Main.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class ScoreToGameOverTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "Your score is: " + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
