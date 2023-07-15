using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class PickCell : ParameterControlCell<Tuple<string, IEnumerable<string>>>
    {
        public PickCell(Parameter parameter, ParameterCollectionViewOptions options) : base(parameter)
        {
            var pickOptions = new InputViews.PickOptions
            {
                LabelOptions = options.ParameterNameLabelOptions(parameter.Key),
                Options = parameter.GetChoices(),
                Value = parameter.GetValue<string>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                ReadOnly = options.ReadOnly,
                NormalTextOptions = options.NormalTextOptions(string.Empty),
                BorderOptions = options.BorderOptions
            };

            View = new PickView(pickOptions);
        }

        /// <summary>
        /// Generetes and return new parameter with the correct name and evt. additionalInfo based on the changes done in the cell. Mark that this will not check if value is valid or not.
        /// </summary>
        /// <returns></returns>
        public override Parameter GetParameter()
        {
            if (_parameter.Type == ParameterType.Enum)
            {
                return new Parameter(_parameter.Key, new Tuple<string, IEnumerable<string>, string>(GetValue().Item1, _parameter.GetChoices(), _parameter.GetValue<ParameterCollection>().GetByKey<string>("type")), _parameter.Type, _parameter.GetAdditionalInfo(), _parameter.GetCustomConverters(), Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            else if (_parameter.Type == ParameterType.SelectOne)
            {
                return new Parameter(_parameter.Key, GetValue().Item1, _parameter.GetChoices(), _parameter.GetAdditionalInfo(), _parameter.GetCustomConverters(), Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            else
            {
                throw new ArgumentException("Parameter need to be of type Enum or SelectOne", nameof(_parameter));
            }
        }

        public override Tuple<string, IEnumerable<string>> GetValue()
        {
            var res = ((PickView)View).GetValue();
            return new Tuple<string, IEnumerable<string>>(res.Item1, res.Item2);
        }
    }
}

