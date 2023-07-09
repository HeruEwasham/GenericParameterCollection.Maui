using CommunityToolkit.Maui.Views;
using YngveHestem.GenericParameterCollection;
using YngveHestem.GenericParameterCollection.Maui;

namespace TestProject;

public class ParameterCollectionTestPage : ContentPage
{
    public ParameterCollection Parameters = new ParameterCollection
        {
            new Parameter("Test string simple", "This is a test"),
            new Parameter("Test string multiline", "This is a string.\n\nThis is another line.", true),
            new Parameter("test boolean", true),
            new Parameter("WhatIs this number", (int)-1),
            new Parameter("A decimal number", 0.56f),
            new Parameter("Date", DateTime.Now, true),
            new Parameter("Date and time", DateTime.Now, false),
            new Parameter("Choose a keyboard flag", KeyboardFlags.All),
            new Parameter("Choose a keyboard flag (with an option for showing as list with selection)", KeyboardFlags.CapitalizeNone, new ParameterCollection
            {
                { "enumSelection", "SelectFromList" }
            }),
            new Parameter("Choose something", "Option 1", new string[] { "Option 1", "Option 2", "Option 92", "Option 3"}),
            new Parameter("Choose something 2", new string[] { "Option 1", "Option 3" }, new string[] { "Option 1", "Option 2", "Option 92", "Option 3", "Option 4"}),
            new Parameter("Choose something 3", new string[] { }, new string[] { "Option 1", "Option 2", "Option 92", "Option 3", "Option 4"}),
            new Parameter("Some more questions", new ParameterCollection
            {
                { "Param1", true },
                { "Param2", "title test" },
                { "Description", "Title", true },
                { "Actors", new string[] { } }
            }),
            new Parameter("A question", new string[] { "new test", "test 2" }),
            new Parameter("Some dates", new DateTime[] { DateTime.Now, DateTime.MaxValue, DateTime.MinValue, DateTime.UtcNow, new DateTime(2021, 06, 15) }, true),
            new Parameter("Some dates and times", new DateTime[] { DateTime.Now, DateTime.MaxValue, DateTime.MinValue, DateTime.UtcNow, new DateTime(2021, 06, 15) }, false),
            new Parameter("Bytes without content", new byte[0], new ParameterCollection
            {
                { "supportedExtensions", new[] {".jpg", ".bmp", ".m4v", ".mp4", ".mkv"} }
            }),
            new Parameter("Bytes with content", new byte[] { 5, 2 }),
            new Parameter("number", 1)
        };

    private Editor _editor = new Editor
    {
        IsEnabled = false
    };

    public ParameterCollectionTestPage()
	{
        _editor.Text = Parameters.ToString();
        var button = new Button
        {
            Text = "Open parameters"
        };
        button.Clicked += async (s, e) =>
        {
            var popup = new ParameterCollectionPopup(Parameters, this);
            var result = await this.ShowPopupAsync(popup);

            if (result is ParameterCollection parameters)
            {
                if (parameters != null)
                {
                    Parameters = parameters;
                    _editor.Text = Parameters.ToString();
                }
            }
        };

        var grid = new Grid
        {
            RowDefinitions = new RowDefinitionCollection(new RowDefinition(50), new RowDefinition(GridLength.Star))
        };
        grid.Add(button, 0, 0);
        grid.Add(new ScrollView
        {
            Content = _editor
        }, 0, 1);
        Content = grid;
    }
}
