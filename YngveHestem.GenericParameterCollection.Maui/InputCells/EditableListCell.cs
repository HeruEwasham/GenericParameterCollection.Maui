using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class EditableListCell<TControlType, TValue> : ParameterControlCell<List<TValue>> where TControlType : ControlView<TValue>
    {
		public EditableListCell(Parameter parameter, TValue defaultValue, ParameterCollectionViewOptions options, Page parentPage) : base(parameter)
		{
            var viewOptions = new EditableListOptions<TValue>
            {
                LabelOptions = options.CellTitleLabelOptions(parameter.Key),
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

