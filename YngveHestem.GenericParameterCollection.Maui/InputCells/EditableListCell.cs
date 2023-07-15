using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class EditableListCell<TControlType, TValue> : ParameterControlCell<List<TValue>> where TControlType : ControlView<TValue>
    {
		public EditableListCell(Parameter parameter, TValue defaultValue, ParameterCollectionViewOptions options, Page parentPage) : base(parameter)
		{
            if (parameter.HasAdditionalInfo())
            {
                var additionalInfo = parameter.GetAdditionalInfo();
                if (additionalInfo.HasKeyAndCanConvertTo("defaultValue", typeof(TValue), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    defaultValue = additionalInfo.GetByKey<TValue>("defaultValue", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }
            }
            var viewOptions = new EditableListOptions<TValue>
            {
                LabelOptions = options.ParameterNameLabelOptions(parameter.Key),
                Value = parameter.GetValue<List<TValue>>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                DefaultValue = defaultValue,
                ParameterCollectionViewOptions = options,
                ParameterType = parameter.Type,
                ReadOnly = options.ReadOnly,
                NormalTextOptions = options.NormalTextOptions(string.Empty),
                SelectButtonOptions = options.SubmitAddOptions(string.Empty),
                BorderOptions = options.BorderOptions
            };

            View = new EditableListView<TControlType, TValue>(viewOptions, parentPage);
		}

        public override List<TValue> GetValue()
        {
            return ((EditableListView<TControlType, TValue>)View).GetValue();
        }
    }
}

