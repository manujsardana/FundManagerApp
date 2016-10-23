using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FundManager.Converters
{
    /// <summary>
    /// Converter to convert the Bool to a Brush based on condition.
    /// </summary>
    public class BooleanToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Convert method to convert types based on values.
        /// </summary>
        /// <param name="value">Value to be assessed.</param>
        /// <param name="targetType">Target Type.</param>
        /// <param name="parameter">Parameters which can be passed from UI.</param>
        /// <param name="culture">UI Culture.</param>
        /// <returns>Returns the converted object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return new SolidColorBrush(Colors.Red);
                }
            }
            return new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// Method to convert the values back.
        /// </summary>
        /// <param name="value">Value to assessed.</param>
        /// <param name="targetType">Target type.</param>
        /// <param name="parameter">Parameter which can be passed from UI.</param>
        /// <param name="culture">UI Culture.</param>
        /// <returns>Returns the converted value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
