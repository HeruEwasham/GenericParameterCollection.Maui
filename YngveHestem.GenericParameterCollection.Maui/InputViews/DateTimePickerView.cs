namespace MediaAndMetadataOrganiser.InputPages.InputViews;

public class DateTimePickerView : ContentView
{
    private DatePicker _datePicker;
    private TimePicker _timePicker;

    public DateTimePickerView(DateTimePickerOptions dateTimePickerOptions)
	{
        var view = new VerticalStackLayout();
        if (dateTimePickerOptions.LabelOptions != null)
        {
            view.Add(dateTimePickerOptions.LabelOptions.CreateLabel());
        }
        
        _datePicker = new DatePicker
        {
            Date = dateTimePickerOptions.Value,
            MinimumDate = dateTimePickerOptions.MinimumDate,
            MaximumDate = dateTimePickerOptions.MaximumDate
        };
        view.Add(_datePicker);

        if (!dateTimePickerOptions.PickOnlyDate)
        {
            _timePicker = new TimePicker
            {
                Time = dateTimePickerOptions.Value.TimeOfDay
            };
            view.Add(_timePicker);
        }

        Content = view;
	}

    public DateTime GetValue()
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
