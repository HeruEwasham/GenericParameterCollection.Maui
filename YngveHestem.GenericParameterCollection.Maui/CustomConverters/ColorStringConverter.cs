using System;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
    public class ColorStringConverter : IParameterValueConverter
    {
        public bool CanConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (targetType == typeof(Color) && sourceType == ParameterType.String)
            {
                return new ColorTypeConverter().ConvertFromString(rawValue.ToObject<string>(jsonSerializer)) != null;
            }
            return false;
        }

        public bool CanConvertFromValue(ParameterType targetType, Type sourceType, object value)
        {
            return sourceType == typeof(Color) && targetType == ParameterType.String;
        }

        public object ConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (targetType == typeof(Color) && sourceType == ParameterType.String)
            {
                var obj = new ColorTypeConverter().ConvertFromString(rawValue.ToObject<string>(jsonSerializer));

                if (obj != null)
                {
                    return obj;
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(ColorStringConverter));
        }

        public JToken ConvertFromValue(ParameterType targetType, Type sourceType, object value, JsonSerializer jsonSerializer)
        {
            if (sourceType == typeof(Color) && targetType == ParameterType.String)
            {
                var str = new ColorTypeConverter().ConvertTo(value, typeof(string));

                if (str != null)
                {
                    return JToken.FromObject(str);
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(ColorStringConverter));
        }
    }
}

