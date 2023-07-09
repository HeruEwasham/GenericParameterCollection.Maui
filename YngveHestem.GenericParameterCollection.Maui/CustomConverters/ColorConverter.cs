using System;
using Microsoft.Maui.Graphics;
using YngveHestem.GenericParameterCollection.ParameterValueConverters;

namespace YngveHestem.GenericParameterCollection.Maui.CustomConverters
{
    public class ColorConverter : ParameterCollectionParameterConverter<Color>
    {
        protected override bool CanConvertFromParameterCollection(ParameterCollection value)
        {
            if (value.HasKeyAndCanConvertTo("r", typeof(float))
                && value.HasKeyAndCanConvertTo("g", typeof(float))
                && value.HasKeyAndCanConvertTo("b", typeof(float))
                && value.HasKeyAndCanConvertTo("a", typeof(float))) {
                return true;
            }
            return false;
        }

        protected override bool CanConvertToParameterCollection(Color value)
        {
            return true;
        }

        protected override Color ConvertFromParameterCollection(ParameterCollection value)
        {
            return Color.FromRgba(value.GetByKey<float>("r"), value.GetByKey<float>("g"), value.GetByKey<float>("b"), value.GetByKey<float>("a"));
        }

        protected override ParameterCollection ConvertToParameterCollection(Color value)
        {
            return new ParameterCollection
            {
                { "r", value.Red },
                { "g", value.Green },
                { "b", value.Blue },
                { "a", value.Alpha }
            };
        }
    }
}

