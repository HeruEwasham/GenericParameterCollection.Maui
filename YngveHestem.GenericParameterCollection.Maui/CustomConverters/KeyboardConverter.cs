using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
    public class KeyboardConverter : IParameterValueConverter
    {
        private static readonly string[] KeyboardTypes = new string[]
        {
            "default",
            "chat",
            "email",
            "numeric",
            "plain",
            "telephone",
            "text",
            "url"
        };

        public bool CanConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (targetType != typeof(Keyboard))
            {
                return false;
            }

            if (sourceType == ParameterType.String)
            {
                var value = rawValue.ToObject<string>(jsonSerializer).ToLower();
                return KeyboardTypes.Contains(value) || Enum.TryParse(typeof(KeyboardFlags), value, true, out _);
            }
            else if (sourceType == ParameterType.ParameterCollection)
            {
                var value = rawValue.ToObject<ParameterCollection>(jsonSerializer);
                if (value.HasKeyAndCanConvertTo("flags", typeof(string)))
                {
                    var s = value.GetByKey<string>("flags").ToLower();
                    return KeyboardTypes.Contains(s) || Enum.TryParse(typeof(KeyboardFlags), s, true, out _);
                }
                else if (value.HasKeyAndCanConvertTo("type", typeof(string)))
                {
                    var s = value.GetByKey<string>("type").ToLower();
                    return KeyboardTypes.Contains(s) || Enum.TryParse(typeof(KeyboardFlags), s, true, out _);
                }
                else if (value.HasKeyAndCanConvertTo("name", typeof(string)))
                {
                    var s = value.GetByKey<string>("name").ToLower();
                    return KeyboardTypes.Contains(s) || Enum.TryParse(typeof(KeyboardFlags), s, true, out _);
                }
            }

            return false;
        }

        public bool CanConvertFromValue(ParameterType targetType, Type sourceType, object value)
        {
            return typeof(CustomKeyboard).IsAssignableFrom(sourceType) && (targetType == ParameterType.String || targetType == ParameterType.ParameterCollection);
        }

        public object ConvertFromParameter(ParameterType sourceType, Type targetType, JToken rawValue, JsonSerializer jsonSerializer)
        {
            if (targetType == typeof(Keyboard))
            {
                if (sourceType == ParameterType.String)
                {
                    return GetKeyboard(rawValue.ToObject<string>(jsonSerializer).ToLower());
                }
                else if (sourceType == ParameterType.ParameterCollection)
                {
                    var value = rawValue.ToObject<ParameterCollection>(jsonSerializer);
                    if (value.HasKeyAndCanConvertTo("flags", typeof(string)))
                    {
                        return GetKeyboard(value.GetByKey<string>("flags").ToLower());
                    }
                    else if (value.HasKeyAndCanConvertTo("type", typeof(string)))
                    {
                        return GetKeyboard(value.GetByKey<string>("type").ToLower());
                    }
                    else if (value.HasKeyAndCanConvertTo("name", typeof(string)))
                    {
                        return GetKeyboard(value.GetByKey<string>("name").ToLower());
                    }
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(KeyboardConverter));
        }

        public JToken ConvertFromValue(ParameterType targetType, Type sourceType, object value, JsonSerializer jsonSerializer)
        {
            if (typeof(CustomKeyboard).IsAssignableFrom(sourceType))
            {
                var keyboard = (CustomKeyboard)value;
                var flags = Enum.GetName(typeof(KeyboardFlags), keyboard.Flags);
                if (targetType == ParameterType.String)
                {
                    return JToken.FromObject(flags, jsonSerializer);
                }
                else if (targetType == ParameterType.ParameterCollection)
                {
                    return JToken.FromObject(new ParameterCollection
                    {
                        { "flags", Enum.GetName(typeof(KeyboardFlags), keyboard.Flags), ParameterType.String }
                    }, jsonSerializer);
                }
            }

            throw new ArgumentException("The values was not supported to be converted by " + nameof(KeyboardConverter));
        }

        private Keyboard GetKeyboard(string value)
        {
            if (value == "default")
            {
                return Keyboard.Default;
            }
            else if (value == "chat")
            {
                return Keyboard.Chat;
            }
            else if (value == "email")
            {
                return Keyboard.Email;
            }
            else if (value == "numeric")
            {
                return Keyboard.Numeric;
            }
            else if (value == "plain")
            {
                return Keyboard.Plain;
            }
            else if (value == "telephone")
            {
                return Keyboard.Telephone;
            }
            else if (value == "text")
            {
                return Keyboard.Text;
            }
            else if (value == "url")
            {
                return Keyboard.Url;
            }
            else if (Enum.TryParse(typeof(KeyboardFlags), value, true, out var flags))
            {
                return Keyboard.Create((KeyboardFlags)flags);
            }
            else
            {
                return Keyboard.Default;
            }
        }
    }
}

