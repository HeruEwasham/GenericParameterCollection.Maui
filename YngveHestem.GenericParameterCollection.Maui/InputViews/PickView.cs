namespace YngveHestem.GenericParameterCollection.Maui.InputViews;

internal class PickView : ControlView<Tuple<string, IEnumerable<string>>>
{
    private Picker _picker;

    public PickView(PickOptions options)
	{
        _picker = new Picker
        {
            HorizontalOptions = new LayoutOptions
            {
                Alignment = LayoutAlignment.Fill
            },
            IsEnabled = !options.ReadOnly,
            TextColor = options.NormalTextOptions.TextColor,
            BackgroundColor = options.NormalTextOptions.BackgroundColor,
            FontAttributes = options.NormalTextOptions.FontAttributes,
            FontFamily = options.NormalTextOptions.FontFamily,
            FontSize = options.NormalTextOptions.FontSize
        };
        foreach (var item in options.Options)
        {
            _picker.Items.Add(item);
        }
		_picker.SelectedItem = options.Value;
        SetView(options.LabelOptions, _picker, options.BorderOptions);
	}

	public string GetSelectedValue()
	{
		return _picker.Items[_picker.SelectedIndex];
    }

    public List<string> GetOptions()
    {
        return _picker.Items.ToList();
    }

    public override Tuple<string, IEnumerable<string>> GetValue()
    {
        return new Tuple<string, IEnumerable<string>>(GetSelectedValue(), GetOptions());
    }
}
