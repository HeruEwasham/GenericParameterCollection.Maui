﻿namespace YngveHestem.GenericParameterCollection.Maui.InputViews;

internal class DateTimePickerView : ControlView<DateTime>
{
    private DatePicker _datePicker;
    private TimePicker _timePicker;

    public DateTimePickerView(DateTimePickerOptions options)
	{
        var columnDef = new ColumnDefinitionCollection { new ColumnDefinition(GridLength.Star) };

        if (!options.PickOnlyDate)
        {
            columnDef.Add(new ColumnDefinition(GridLength.Star));
        }

        var view = new Grid
        {
            ColumnDefinitions = columnDef
        };
        
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
        view.Add(_datePicker, 0);

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
            view.Add(_timePicker, 1);
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
