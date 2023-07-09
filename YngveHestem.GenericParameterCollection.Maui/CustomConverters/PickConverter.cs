using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
    public class PickConverter : IParameterValueConverter
    {
        public bool CanConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            return (typeof(Tuple<string, IEnumerable<string>>).IsAssignableFrom(targetType) && (sourceType == ParameterType.Enum || sourceType == ParameterType.SelectOne))
                || (typeof(Tuple<IEnumerable<string>, IEnumerable<string>>).IsAssignableFrom(targetType) && (sourceType == ParameterType.SelectMany || sourceType == ParameterType.Enum || sourceType == ParameterType.SelectOne));
        }

        public bool CanConvertFromValue(ParameterType targetType, Type sourceType, object value)
        {
            return (typeof(Tuple<string, IEnumerable<string>, string>).IsAssignableFrom(sourceType) && targetType == ParameterType.Enum)
                || (typeof(Tuple<string, IEnumerable<string>>).IsAssignableFrom(sourceType) && targetType == ParameterType.SelectOne)
                || (typeof(Tuple<IEnumerable<string>, IEnumerable<string>>).IsAssignableFrom(sourceType) && targetType == ParameterType.SelectMany);
        }

        public object ConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if ((sourceType == ParameterType.Enum || sourceType == ParameterType.SelectOne) && typeof(Tuple<string, IEnumerable<string>>).IsAssignableFrom(targetType))
            {
                var v = rawValue.ToObject<ParameterCollection>();
                return new Tuple<string, IEnumerable<string>>(v.GetByKey<string>("value"), v.GetByKey<IEnumerable<string>>("choices"));
            }
            else if ((sourceType == ParameterType.SelectMany || sourceType == ParameterType.Enum || sourceType == ParameterType.SelectOne) && typeof(Tuple<IEnumerable<string>, IEnumerable<string>>).IsAssignableFrom(targetType))
            {
                var v = rawValue.ToObject<ParameterCollection>();
                return new Tuple<IEnumerable<string>, IEnumerable<string>>(v.GetByKey<IEnumerable<string>>("value"), v.GetByKey<IEnumerable<string>>("choices"));
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(PickConverter));
        }

        public JToken ConvertFromValue(ParameterType targetType, Type sourceType, object value, JsonSerializer jsonSerializer)
        {
            if (targetType == ParameterType.Enum && typeof(Tuple<string, IEnumerable<string>, string>).IsAssignableFrom(sourceType))
            {
                var v = (Tuple<string, IEnumerable<string>, string>)value;
                return JToken.FromObject(new ParameterCollection
                {
                    { "value", v.Item1 },
                    { "choices", v.Item2 },
                    { "type", v.Item3 }
                });
            }
            else if (targetType == ParameterType.SelectOne && typeof(Tuple<string, IEnumerable<string>>).IsAssignableFrom(sourceType))
            {
                var v = (Tuple<string, IEnumerable<string>>)value;
                return JToken.FromObject(new ParameterCollection
                {
                    { "value", v.Item1 },
                    { "choices", v.Item2 }
                });
            }
            else if (targetType == ParameterType.SelectMany && typeof(Tuple<IEnumerable<string>, IEnumerable<string>>).IsAssignableFrom(sourceType))
            {
                var v = (Tuple<IEnumerable<string>, IEnumerable<string>>)value;
                return JToken.FromObject(new ParameterCollection
                {
                    { "value", v.Item1 },
                    { "choices", v.Item2 }
                });
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(PickConverter));
        }
    }
}

