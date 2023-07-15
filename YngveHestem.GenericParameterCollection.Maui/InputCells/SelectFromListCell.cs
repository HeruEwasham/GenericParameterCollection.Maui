using System;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
	internal class SelectFromListCell : ParameterControlCell<Tuple<IEnumerable<string>, IEnumerable<string>>>
    {
        public SelectFromListCell(Parameter parameter, ParameterCollectionViewOptions options) : base(parameter)
        {
            var value = parameter.GetValue<Tuple<IEnumerable<string>, IEnumerable<string>>>(Extensions.CUSTOM_PARAMETER_CONVERTERS);
            var pickOptions = new InputViews.SelectFromListOptions
            {
                LabelOptions = options.ParameterNameLabelOptions(parameter.Key),
                Options = value.Item2,
                Value = value.Item1,
                ReadOnly = options.ReadOnly,
                NormalTextOptions = options.NormalTextOptions(string.Empty),
                BorderOptions = options.BorderOptions
            };

            if (parameter.Type == ParameterType.SelectMany)
            {
                pickOptions.SelectionMode = SelectionMode.Multiple;
            }
            else if (parameter.Type == ParameterType.Enum || parameter.Type == ParameterType.SelectOne)
            {
                pickOptions.SelectionMode = SelectionMode.Single;
            }

            View = new SelectFromListView(pickOptions);
        }

        public override Parameter GetParameter()
        {
            if (_parameter.Type == ParameterType.Enum)
            {
                return new Parameter(_parameter.Key, new Tuple<string, IEnumerable<string>, string>(GetValue().Item1.ToArray()[0], _parameter.GetChoices(), _parameter.GetValue<ParameterCollection>().GetByKey<string>("type")), _parameter.Type, _parameter.GetAdditionalInfo(), _parameter.GetCustomConverters(), Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            else if (_parameter.Type == ParameterType.SelectOne)
            {
                var value = GetValue().Item1;
                var v = string.Empty;
                if (value == null || value.ToArray().Length == 0)
                {
                    v = _parameter.GetValue<string>();
                }
                else
                {
                    v = value.ToArray()[0];
                }
                return new Parameter(_parameter.Key, v, _parameter.GetChoices(), _parameter.GetAdditionalInfo(), _parameter.GetCustomConverters(), Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            else if (_parameter.Type == ParameterType.SelectMany)
            {
                return new Parameter(_parameter.Key, GetValue().Item1, _parameter.GetChoices(), _parameter.GetAdditionalInfo(), _parameter.GetCustomConverters(), Extensions.CUSTOM_PARAMETER_CONVERTERS);
            }
            else
            {
                throw new ArgumentException("Parameter need to be of type Enum or SelectOne", nameof(_parameter));
            }
        }

        public override Tuple<IEnumerable<string>, IEnumerable<string>> GetValue()
        {
            return ((SelectFromListView)View).GetValue();
        }
    }
}

