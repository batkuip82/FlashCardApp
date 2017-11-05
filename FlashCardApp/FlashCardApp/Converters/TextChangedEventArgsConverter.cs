using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FlashCardApp.Converters
{
    public class TextChangedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var textChangedEventArgs = value as TextChangedEventArgs;
            if (textChangedEventArgs == null)
            {
                throw new ArgumentException("Expected value to be of type TextChangedEventArgs", nameof(value));
            }

            return textChangedEventArgs.NewTextValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
