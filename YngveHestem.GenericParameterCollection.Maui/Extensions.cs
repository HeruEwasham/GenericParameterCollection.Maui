using System;
using System.Globalization;
using System.Text.RegularExpressions;
using YngveHestem.GenericParameterCollection.Maui.CustomConverters;
using YngveHestem.GenericParameterCollection.Maui.InputViews;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui
{
    public static class Extensions
    {
        public const string PARAMETER_NAME_VALIDATION_REGEX = "validation regex";
        public const string PARAMETER_NAME_KEYBOARD_TYPE = "keyboard type";
        public const string PARAMETER_NAME_MINIMUM_DATE = "minimum date";
        public const string PARAMETER_NAME_MAXIMUM_DATE = "meximum date";
        public const string PARAMETER_NAME_SUPPORTED_FILE_TYPES = "supported file types";
        public const string PARAMETER_NAME_FILE_EXTENSION = "file extension";
        public const string PARAMETER_NAME_FILE_PATH = "file path";

        public const string PICK_PHOTO_TEXT = "Pick photo from camera roll";
        public const string PICK_VIDEO_TEXT = "Pick video from camera roll";
        public const string PICK_FILE_TEXT = "Pick file";
        public const string PICK_URL_TEXT = "Download file from url";

        public static readonly IParameterValueConverter[] CUSTOM_PARAMETER_CONVERTERS = new IParameterValueConverter[]
        {
            new ColorConverter(),
            new ColorStringConverter(),
            new TextValidationOptionsConverter(),
            new PickConverter(),
            new KeyboardConverter(),
            new ThicknessConverter(),
            new BrushConverter(),
            new IShapeConverter()
        };

        public static string GetSizeInMemory(this int bytesize)
        {
            return GetSizeInMemory((long)bytesize);
        }

        public static string GetSizeInMemory(this long bytesize)
        {
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = Convert.ToDouble(bytesize);
            int order = 0;
            while (len >= 1024D && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            return string.Format(CultureInfo.CurrentCulture, "{0:0.##} {1}", len, sizes[order]);
        }

        /// <summary>
        /// Returns the text with first character as a camel case.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string text)
        {
            return char.ToUpper(text.First()) + text.Substring(1);
        }

        /// <summary>
        /// Returns true as long as it does not find a validation-parameter that validates to false.
        /// </summary>
        /// <param name="parameter">The parameter to validate.</param>
        /// <returns></returns>
        public static bool IsValid(this Parameter parameter)
        {
            if (parameter.HasAdditionalInfo())
            {
                var additionalinfo = parameter.GetAdditionalInfo();
                if (additionalinfo.HasKeyAndCanConvertTo(PARAMETER_NAME_VALIDATION_REGEX, typeof(string)))
                {
                    var regex = additionalinfo.GetByKey<string>(PARAMETER_NAME_VALIDATION_REGEX);
                    if (parameter.Type == ParameterType.String || parameter.Type == ParameterType.String_Multiline)
                    {
                        return Regex.IsMatch(parameter.GetValue<string>(), regex);
                    }
                    else if (parameter.Type == ParameterType.Int)
                    {
                        return Regex.IsMatch(parameter.GetValue<int>().ToString(), regex);
                    }
                    else if (parameter.Type == ParameterType.Float)
                    {
                        return Regex.IsMatch(parameter.GetValue<float>().ToString(), regex);
                    }
                    else if (parameter.Type == ParameterType.Double)
                    {
                        return Regex.IsMatch(parameter.GetValue<double>().ToString(), regex);
                    }
                    else if (parameter.Type == ParameterType.Long)
                    {
                        return Regex.IsMatch(parameter.GetValue<long>().ToString(), regex);
                    }
                    else if (parameter.Type == ParameterType.String_IEnumerable || parameter.Type == ParameterType.String_Multiline_IEnumerable)
                    {
                        return parameter.GetValue<string[]>().All(value => Regex.IsMatch(value, regex));
                    }
                    else if (parameter.Type == ParameterType.Int_IEnumerable)
                    {
                        return parameter.GetValue<int[]>().All(value => Regex.IsMatch(value.ToString(), regex));
                    }
                    else if (parameter.Type == ParameterType.Float_IEnumerable)
                    {
                        return parameter.GetValue<float[]>().All(value => Regex.IsMatch(value.ToString(), regex));
                    }
                    else if (parameter.Type == ParameterType.Double_IEnumerable)
                    {
                        return parameter.GetValue<double[]>().All(value => Regex.IsMatch(value.ToString(), regex));
                    }
                    else if (parameter.Type == ParameterType.Long_IEnumerable)
                    {
                        return parameter.GetValue<double[]>().All(value => Regex.IsMatch(value.ToString(), regex));
                    }
                    else if (parameter.Type == ParameterType.ParameterCollection)
                    {
                        return parameter.GetValue<ParameterCollection>().All(p => p.IsValid());
                    }
                    else if (parameter.Type == ParameterType.ParameterCollection_IEnumerable)
                    {
                        return parameter.GetValue<ParameterCollection[]>().All(pc => pc.All(p => p.IsValid()));
                    }
                }
            }

            return true;
        }
    }
}

