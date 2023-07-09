using System;
using CommunityToolkit.Maui.Behaviors;

namespace MediaAndMetadataOrganiser.InputPages.InputViews
{
	internal static class InputViewsExtensions
	{
        /// <summary>
        /// Creates a label based on the given parameters.
        /// </summary>
        /// <returns></returns>
        public static Label CreateLabel(this LabelOptions options)
        {
            return new Label
            {
                Text = options.Text,
                TextColor = options.TextColor,
                BackgroundColor = options.BackgroundColor,
                FontFamily = options.FontFamily,
                FontSize = options.FontSize,
                FontAttributes = options.FontAttributes,
                LineBreakMode = options.LineBreakMode
            };
        }

        /// <summary>
        /// Creates a button based on the given parameters.
        /// </summary>
        /// <returns></returns>
        public static Button CreateButton(this LabelOptions options)
        {
            return new Button
            {
                Text = options.Text,
                TextColor = options.TextColor,
                BackgroundColor = options.BackgroundColor,
                FontFamily = options.FontFamily,
                FontSize = options.FontSize,
                FontAttributes = options.FontAttributes,
                LineBreakMode = options.LineBreakMode
            };
        }
    }
}

