namespace MediaAndMetadataOrganiser.InputPages.InputViews;

public class PickView : ContentView
{
    private Picker _picker;

    public PickView(PickOptions options)
	{
		var view = new HorizontalStackLayout();

        if (options.LabelOptions != null)
        {
            view.Add(options.LabelOptions.CreateLabel());
        }

        _picker = new Picker();
        foreach (var item in options.Options)
        {
            _picker.Items.Add(item);
        }
		_picker.SelectedItem = options.Value;
		view.Add(_picker);

        Content = view;
	}

	public string GetValue()
	{
		return _picker.Items[_picker.SelectedIndex];
    }
}
