using System;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class DateTimePickerCell : ParameterControlCell<DateTime>
    {
        public DateTimePickerCell(Parameter parameter, ParameterCollectionViewOptions options) : base(parameter)
        {
            var dateTimePickerOptions = new DateTimePickerOptions
            {
                LabelOptions = options.CellTitleLabelOptions(parameter.Key),
                Value = parameter.GetValue<DateTime>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                PickOnlyDate = parameter.Type == ParameterType.Date,
                MinimumDate = options.MinDate,
                MaximumDate = options.MaxDate,
                ReadOnly = options.ReadOnly,
                NormalTextOptions = options.NormalTextOptions(string.Empty),
                BorderOptions = options.BorderOptions
            };

            View = new DateTimePickerView(dateTimePickerOptions);
        }

        public override DateTime GetValue()
        {
            return ((DateTimePickerView)View).GetValue();
        }
    }
}

