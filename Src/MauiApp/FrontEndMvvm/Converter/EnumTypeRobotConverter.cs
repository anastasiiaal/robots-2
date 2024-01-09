using FrontEndMvvm.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndMvvm.Converter
{
    public class EnumTypeRobotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            EnumTypeRobot currentValue = (EnumTypeRobot)value;
            switch (currentValue)
            {
                case EnumTypeRobot.DroideDeProtocole:
                    return "Droïde de protocole";
                case EnumTypeRobot.DroideAstromecano:
                    return "Droïde astromécano";
                default:
                    return "Droïde de protocole";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentValue = (string)value;
            switch (currentValue)
            {
                case "Droïde de protocole":
                    return EnumTypeRobot.DroideDeProtocole;
                case "Droïde astromécano":
                    return EnumTypeRobot.DroideAstromecano;
                default:
                    return EnumTypeRobot.DroideDeProtocole;
            }
        }
    }
}
