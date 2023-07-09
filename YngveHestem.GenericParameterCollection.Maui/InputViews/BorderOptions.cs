using Microsoft.Maui.Controls.Shapes;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
    public class BorderOptions
    {
        public static readonly BorderOptions Default = new();

        /// <summary>
        /// Represents the distance between the border and its child element.
        /// </summary>
        public Thickness Padding = Thickness.Zero;

        /// <summary>
        /// Describes the shape of the border. Default is a Rectangle.
        /// </summary>
        public IShape StrokeShape = new Rectangle();

        /// <summary>
        /// Indicates the brush used to paint the border.
        /// </summary>
        public Brush Stroke = Colors.Black;

        /// <summary>
        /// Indicates the width of the border. The default value of this property is 1.0.
        /// </summary>
        public double StrokeThickness = 1.0;

        /// <summary>
        /// Represents a collection of double values that indicate the pattern of dashes and gaps that make up the border.
        /// </summary>
        public DoubleCollection StrokeDashArray = new();

        /// <summary>
        /// Specifies the distance within the dash pattern where a dash begins. The default value of this property is 0.0.
        /// </summary>
        public double StrokeDashOffset = 0.0;

        /// <summary>
        /// Describes the shape at the start and end of its line. The default value of this property is PenLineCap.Flat.
        /// </summary>
        public PenLineCap StrokeLineCap = PenLineCap.Flat;

        /// <summary>
        /// specifies the type of join that is used at the vertices of the stroke shape. The default value of this property is PenLineJoin.Miter.
        /// </summary>
        public PenLineJoin StrokeLineJoin = PenLineJoin.Miter;

        /// <summary>
        /// Specifies the limit on the ratio of the miter length to half the stroke thickness. The default value of this property is 10.0.
        /// </summary>
        public double StrokeMiterLimit = 10.0;

        public Border CreateBorder(View content)
        {
            return new Border
            {
                Padding = Padding,
                StrokeShape = StrokeShape,
                Stroke = Stroke,
                StrokeThickness = StrokeThickness,
                StrokeDashArray = StrokeDashArray,
                StrokeDashOffset = StrokeDashOffset,
                StrokeLineCap = StrokeLineCap,
                StrokeLineJoin = StrokeLineJoin,
                StrokeMiterLimit = StrokeMiterLimit,
                Content = content
            };
        }

        public static BorderOptions CreateCopy(BorderOptions options)
        {
            return new BorderOptions
            {
                Padding = options.Padding,
                StrokeShape = options.StrokeShape,
                Stroke = options.Stroke,
                StrokeThickness = options.StrokeThickness,
                StrokeDashArray = options.StrokeDashArray,
                StrokeDashOffset = options.StrokeDashOffset,
                StrokeLineCap = options.StrokeLineCap,
                StrokeLineJoin = options.StrokeLineJoin,
                StrokeMiterLimit = options.StrokeMiterLimit
            };
        }
        public static BorderOptions CreateFromParameterCollection(ParameterCollection parameters, BorderOptions defaultOptions = null)
        {
            var result = new BorderOptions();
            if (defaultOptions != null)
            {
                result = CreateCopy(defaultOptions);
            }

            if (parameters != null)
            {
                if (parameters.HasKeyAndCanConvertTo("padding", typeof(Thickness), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.Padding = parameters.GetByKey<Thickness>("padding", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("shape", typeof(IShape), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeShape = parameters.GetByKey<IShape>("shape", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("stroke", typeof(Brush), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.Stroke = parameters.GetByKey<Brush>("stroke", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("thickness", typeof(double), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeThickness = parameters.GetByKey<double>("thickness", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("strokeDashArray", typeof(DoubleCollection), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeDashArray = parameters.GetByKey<DoubleCollection>("strokeDashArray", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("strokeDashOffset", typeof(double), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeDashOffset = parameters.GetByKey<double>("strokeDashOffset", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("lineCap", typeof(PenLineCap), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeLineCap = parameters.GetByKey<PenLineCap>("lineCap", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("lineJoin", typeof(PenLineJoin), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeLineJoin = parameters.GetByKey<PenLineJoin>("lineJoin", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("miterLimit", typeof(double), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.StrokeMiterLimit = parameters.GetByKey<double>("miterLimit", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }
            }

            return result;
        }
    }
}