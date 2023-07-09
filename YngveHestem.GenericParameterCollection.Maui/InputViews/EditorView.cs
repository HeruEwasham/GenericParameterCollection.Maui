using CommunityToolkit.Maui.Behaviors;

namespace MediaAndMetadataOrganiser.InputPages.InputViews;

public class EditorView : ContentView
{
    private Editor _editor;

    public EditorView(EditorOptions options)
	{
		var view = new VerticalStackLayout();

        if (options.LabelOptions != null)
        {
            view.Add(options.LabelOptions.CreateLabel());
        }

        _editor = new Editor
        {
            Text = options.Value,
            Keyboard = options.Keyboard
        };

        if (options.TextValidationOptions != null)
        {
            var validStyle = new Style(typeof(Editor));
            validStyle.Setters.Add(AddSetter(options.TextValidationOptions.ValidColor, options.TextValidationOptions.PropertyToShowStatus));

            var invalidStyle = new Style(typeof(Editor));
            invalidStyle.Setters.Add(AddSetter(options.TextValidationOptions.InvalidColor, options.TextValidationOptions.PropertyToShowStatus));

            var textValidationBehavior = new TextValidationBehavior
            {
                InvalidStyle = invalidStyle,
                ValidStyle = validStyle,
                Flags = options.TextValidationOptions.ValidationFlags,
                RegexPattern = options.TextValidationOptions.ValidationRegex
            };

            _editor.Behaviors.Add(textValidationBehavior);
        }

        view.Add(_editor);

        Content = view;
	}

    public string GetValue()
    {
        return _editor.Text;
    }

    private Setter AddSetter(Color color, PropertyType propertyType)
    {
        var setter = new Setter
        {
            Value = color
        };
        switch(propertyType)
        {
            case PropertyType.TextColor:
                setter.Property = Editor.TextColorProperty;
                break;
            case PropertyType.BackgroundColor:
                setter.Property = Editor.BackgroundColorProperty;
                break;
        }
        return setter;
    }
}
