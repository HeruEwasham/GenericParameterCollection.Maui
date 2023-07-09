using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
    public class ThicknessConverter : IParameterValueConverter
    {
        public bool CanConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (targetType == typeof(Thickness))
            {
                if (sourceType == ParameterType.ParameterCollection)
                {
                    var validType = typeof(double);
                    var parameters = rawValue.ToObject<ParameterCollection>(jsonSerializer);
                    return (parameters.HasKeyAndCanConvertTo("horizontalSize", validType)
                        && parameters.HasKeyAndCanConvertTo("verticalSize", validType))
                        || (parameters.HasKeyAndCanConvertTo("left", validType)
                        && parameters.HasKeyAndCanConvertTo("right", validType)
                        && parameters.HasKeyAndCanConvertTo("top", validType)
                        && parameters.HasKeyAndCanConvertTo("bottom", validType));
                }
                else if (sourceType == ParameterType.Double || sourceType == ParameterType.Float || sourceType == ParameterType.Int || sourceType == ParameterType.Long)
                {
                    return true;
                }
            }
            return false;
        }

        public bool CanConvertFromValue(ParameterType targetType, Type sourceType, object value)
        {
            return sourceType == typeof(Thickness) && (targetType == ParameterType.ParameterCollection || targetType == ParameterType.Double || targetType == ParameterType.Float || targetType == ParameterType.Int || targetType == ParameterType.Long);
        }

        public object ConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (targetType == typeof(Thickness))
            {
                if (sourceType == ParameterType.ParameterCollection)
                {
                    var validType = typeof(double);
                    var parameters = rawValue.ToObject<ParameterCollection>(jsonSerializer);
                    if (parameters.HasKeyAndCanConvertTo("left", validType)
                        && parameters.HasKeyAndCanConvertTo("right", validType)
                        && parameters.HasKeyAndCanConvertTo("top", validType)
                        && parameters.HasKeyAndCanConvertTo("bottom", validType))
                    {
                        return new Thickness(parameters.GetByKey<double>("left"), parameters.GetByKey<double>("top"), parameters.GetByKey<double>("right"), parameters.GetByKey<double>("bottom"));
                    }
                    else if (parameters.HasKeyAndCanConvertTo("horizontalSize", validType)
                        && parameters.HasKeyAndCanConvertTo("verticalSize", validType))
                    {
                        return new Thickness(parameters.GetByKey<double>("horizontalSize"), parameters.GetByKey<double>("verticalSize"));
                    }
                }
                else if (sourceType == ParameterType.Double || sourceType == ParameterType.Float || sourceType == ParameterType.Int || sourceType == ParameterType.Long) {
                    return new Thickness(rawValue.ToObject<double>(jsonSerializer));
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(ThicknessConverter));
        }

        public JToken ConvertFromValue(ParameterType targetType, Type sourceType, object value, JsonSerializer jsonSerializer)
        {
            if (sourceType == typeof(Thickness))
            {
                var v = (Thickness)value;
                if (targetType == ParameterType.ParameterCollection)
                {
                    return JToken.FromObject(new ParameterCollection
                    {
                        { "left", v.Left },
                        { "top", v.Top },
                        { "right", v.Right },
                        { "bottom", v.Bottom }
                    });
                }
                else if (targetType == ParameterType.Double || targetType == ParameterType.Float || targetType == ParameterType.Int || targetType == ParameterType.Long)
                {
                    if (v.Left == v.Top && v.Top == v.Right && v.Right == v.Bottom)
                    {
                        return JToken.FromObject(v.Left);
                    }

                    throw new ArgumentException("The values of Thickness must be the same to be able to convert it to a single number by " + nameof(ThicknessConverter));
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(ThicknessConverter));
        }
    }
}

