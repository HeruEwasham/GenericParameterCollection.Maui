using CommunityToolkit.Maui.Behaviors;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews;

internal class SwitchView : ControlView<bool>
{
    private Switch _switch;

    public SwitchView(SwitchOptions options)
	{
        _switch = new Switch
        {
            IsToggled = options.Value,
            HorizontalOptions = LayoutOptions.Start,
            IsEnabled = !options.ReadOnly,
            BackgroundColor = options.NormalBackgroundColor
        };

        SetView(options.LabelOptions, _switch, options.BorderOptions);
	}

    public override bool GetValue()
    {
        return _switch.IsToggled;
    }
}
