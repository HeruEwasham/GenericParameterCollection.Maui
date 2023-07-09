namespace YngveHestem.GenericParameterCollection.Maui.InputViews;

internal class DateTimePickerView : ControlView<DateTime>
{
    private DatePicker _datePicker;
    private TimePicker _timePicker;

    public DateTimePickerView(DateTimePickerOptions options)
	{
        var view = new VerticalStackLayout();
        
        _datePicker = new DatePicker
        {
            Date = options.Value,
            MinimumDate = options.MinimumDate,
            MaximumDate = options.MaximumDate,
            IsEnabled = !options.ReadOnly,
            TextColor = options.NormalTextOptions.TextColor,
            BackgroundColor = options.NormalTextOptions.BackgroundColor,
            FontAttributes = options.NormalTextOptions.FontAttributes,
            FontFamily = options.NormalTextOptions.FontFamily,
            FontSize = options.NormalTextOptions.FontSize
        };
        view.Add(_datePicker);

        if (!options.PickOnlyDate)
        {
            _timePicker = new TimePicker
            {
                Time = options.Value.TimeOfDay,
                IsEnabled = !options.ReadOnly,
                TextColor = options.NormalTextOptions.TextColor,
                BackgroundColor = options.NormalTextOptions.BackgroundColor,
                FontAttributes = options.NormalTextOptions.FontAttributes,
                FontFamily = options.NormalTextOptions.FontFamily,
                FontSize = options.NormalTextOptions.FontSize
            };
            view.Add(_timePicker);
        }

        SetView(options.LabelOptions, view, options.BorderOptions);
	}

    public override DateTime GetValue()
    {
        if (_timePicker != null)
        {
            return _datePicker.Date.Add(_timePicker.Time);
        }
        else
        {
            return _datePicker.Date;
        }
    }
}
