using System;
using CommunityToolkit.Maui.Behaviors;
using Microsoft.Maui.Graphics;
using YngveHestem.GenericParameterCollection.Maui.InputViews;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
    public class TextValidationOptionsConverter : ParameterCollectionParameterConverter<TextValidationOptions>
    {
        protected override bool CanConvertFromParameterCollection(ParameterCollection value)
        {
            if (value.HasKeyAndCanConvertTo("regex", typeof(string))
                || value.HasKeyAndCanConvertTo("validColor", typeof(Color), Extensions.CUSTOM_PARAMETER_CONVERTERS)
                || value.HasKeyAndCanConvertTo("invalidColor", typeof(Color), Extensions.CUSTOM_PARAMETER_CONVERTERS)
                || value.HasKeyAndCanConvertTo("statusProperty", typeof(PropertyType))
                || value.HasKeyAndCanConvertTo("flags", typeof(ValidationFlags)))
            {
                return true;
            }
            return false;
        }

        protected override bool CanConvertToParameterCollection(TextValidationOptions value)
        {
            return true;
        }

        protected override TextValidationOptions ConvertFromParameterCollection(ParameterCollection value)
        {
            var result = new TextValidationOptions();

            if (value.HasKeyAndCanConvertTo("regex", typeof(string)))
            {
                result.ValidationRegex = value.GetByKey<string>("regex");
            }
            if (value.HasKeyAndCanConvertTo("validColor", typeof(Color), Extensions.CUSTOM_PARAMETER_CONVERTERS))
            {
                result.ValidColor = value.GetByKey<Color>("validColor", Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            if (value.HasKeyAndCanConvertTo("invalidColor", typeof(Color), Extensions.CUSTOM_PARAMETER_CONVERTERS))
            {
                result.InvalidColor = value.GetByKey<Color>("invalidColor", Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            if (value.HasKeyAndCanConvertTo("statusProperty", typeof(PropertyType)))
            {
                result.PropertyToShowStatus = value.GetByKey<PropertyType>("statusProperty");
            }
            if (value.HasKeyAndCanConvertTo("flags", typeof(ValidationFlags)))
            {
                result.ValidationFlags = value.GetByKey<ValidationFlags>("flags");
            }

            return result;
        }

        protected override ParameterCollection ConvertToParameterCollection(TextValidationOptions value)
        {
            return new ParameterCollection(new Parameter[]
            {
                new Parameter("regex", value.ValidationRegex),
                new Parameter("validColor", value.ValidColor, ParameterType.ParameterCollection, null, null, Extensions.CUSTOM_PARAMETER_CONVERTERS),
                new Parameter("invalidColor", value.InvalidColor, ParameterType.ParameterCollection, null, null, Extensions.CUSTOM_PARAMETER_CONVERTERS),
                new Parameter("statusProperty", value.PropertyToShowStatus),
                new Parameter("flags", value.ValidationFlags)
            }, null);
        }
    }
}

