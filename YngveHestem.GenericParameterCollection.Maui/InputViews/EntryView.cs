using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Storage;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews;

internal class EntryView : ControlView<string>
{
    private Entry _editor;

    public EntryView(EntryEditorOptions options)
	{
        _editor = new Entry
        {
            Text = options.Value,
            Keyboard = options.Keyboard,
            IsReadOnly = options.ReadOnly,
            TextColor = options.NormalTextOptions.TextColor,
            BackgroundColor = options.NormalTextOptions.BackgroundColor,
            FontAttributes = options.NormalTextOptions.FontAttributes,
            FontFamily = options.NormalTextOptions.FontFamily,
            FontSize = options.NormalTextOptions.FontSize
        };

        if (options.TextValidationOptions != null)
        {
            var validStyle = new Style(typeof(Entry));
            validStyle.Setters.Add(AddSetter(options.TextValidationOptions.ValidColor, options.TextValidationOptions.PropertyToShowStatus));

            var invalidStyle = new Style(typeof(Entry));
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

        if (!options.ReadOnly && options.ShowFolderPicker)
        {
            var folderButton = options.NormalTextOptions.CreateButton();
            folderButton.Text = options.FolderPickerText;
            folderButton.Clicked += FolderButtonClickedAsync;
            _editor.IsReadOnly = options.TextReadOnlyWhenPickerIsShown;
            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection(new ColumnDefinition(GridLength.Star), new ColumnDefinition(GridLength.Star))
            };
            grid.Add(_editor, 0);
            grid.Add(folderButton, 1);
            SetView(options.LabelOptions, grid, options.BorderOptions);
        }
        else
        {
            SetView(options.LabelOptions, _editor, options.BorderOptions);
        }
	}

    private async void FolderButtonClickedAsync(object sender, EventArgs e)
    {
        var result = await FolderPicker.Default.PickAsync(_editor.Text, CancellationToken.None);
        if (result != null && result.IsSuccessful)
        {
            _editor.Text = result.Folder.Path;
        }
    }

    public override string GetValue()
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
