using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class SwitchCell : ParameterControlCell<bool>
	{
        public SwitchCell(Parameter parameter, ParameterCollectionViewOptions options) : base(parameter)
        {
            View = new SwitchView(new SwitchOptions
            {
                LabelOptions = options.ParameterNameLabelOptions(parameter.Key),
                Value = parameter.GetValue<bool>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                ReadOnly = options.ReadOnly,
                NormalBackgroundColor = options.NormalBackgroundColor,
                BorderOptions = options.BorderOptions
            });
        }

        public override bool GetValue()
        {
            return ((SwitchView)View).GetValue();
        }
    }
}

