using System;
using Microsoft.Maui.Controls.Shapes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
	public class BrushConverter : IParameterValueConverter
	{
        public bool CanConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (typeof(Brush).IsAssignableFrom(targetType) && sourceType == ParameterType.String)
            {
                return new BrushTypeConverter().ConvertFromString(rawValue.ToObject<string>(jsonSerializer)) != null;
            }
            return false;
        }

        public bool CanConvertFromValue(ParameterType targetType, Type sourceType, object value)
        {
            return typeof(Brush).IsAssignableFrom(sourceType) && targetType == ParameterType.String;
        }

        public object ConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (typeof(Brush).IsAssignableFrom(targetType) && sourceType == ParameterType.String)
            {
                var obj = new BrushTypeConverter().ConvertFromString(rawValue.ToObject<string>(jsonSerializer));

                if (obj != null)
                {
                    return obj;
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(BrushConverter));
        }

        public JToken ConvertFromValue(ParameterType targetType, Type sourceType, object value, JsonSerializer jsonSerializer)
        {
            if (typeof(Brush).IsAssignableFrom(sourceType) && targetType == ParameterType.String)
            {
                var str = new BrushTypeConverter().ConvertTo(value, typeof(string));

                if (str != null)
                {
                    return JToken.FromObject(str);
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(BrushConverter));
        }
    }
}

