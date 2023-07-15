using System;
using CommunityToolkit.Maui.Behaviors;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	internal static class InputViewsExtensions
	{
        /// <summary>
        /// Creates a label based on the given parameters.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="text">If this is not null, this text will replace the text set in options.</param>
        /// <returns></returns>
        public static Label CreateLabel(this LabelOptions options, string text = null)
        {
            return new Label
            {
                Text = text == null ? options.Text : text,
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

        /// <summary>
        /// Creates a LabelOptions with inputted string as text and ParameterName-options as settings.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static LabelOptions ParameterNameLabelOptions(this ParameterCollectionViewOptions options, string text)
        {
            return new LabelOptions
            {
                Text = options.ShowParameterNameAsHumanReadable ? text.FirstCharToUpper() : text,
                FontAttributes = options.ParameterNameFont.GetFontAttributes(),
                FontFamily = options.ParameterNameFont.Family,
                FontSize = options.ParameterNameFont.Size,
                BackgroundColor = options.ParameterNameBackgroundColor,
                TextColor = options.ParameterNameTextColor
            };
        }

        /// <summary>
        /// Creates a LabelOptions with inputted string as text and NormalText-options as settings.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static LabelOptions NormalTextOptions(this ParameterCollectionViewOptions options, string text)
        {
            return new LabelOptions
            {
                Text = text,
                FontAttributes = options.NormalFont.GetFontAttributes(),
                FontFamily = options.NormalFont.Family,
                FontSize = options.NormalFont.Size,
                BackgroundColor = options.NormalBackgroundColor,
                TextColor = options.NormalTextColor
            };
        }

        /// <summary>
        /// Creates a LabelOptions with inputted string as text and SubmitAdd-options as settings.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static LabelOptions SubmitAddOptions(this ParameterCollectionViewOptions options, string text)
        {
            return new LabelOptions
            {
                Text = text,
                FontAttributes = options.SubmitAddFont.GetFontAttributes(),
                FontFamily = options.SubmitAddFont.Family,
                FontSize = options.SubmitAddFont.Size,
                BackgroundColor = options.SubmitAddBackgroundColor,
                TextColor = options.SubmitAddTextColor
            };
        }

        /// <summary>
        /// Creates a LabelOptions with inputted string as text and CancelDelete-options as settings.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static LabelOptions CancelDeleteOptions(this ParameterCollectionViewOptions options, string text)
        {
            return new LabelOptions
            {
                Text = text,
                FontAttributes = options.CancelDeleteFont.GetFontAttributes(),
                FontFamily = options.CancelDeleteFont.Family,
                FontSize = options.CancelDeleteFont.Size,
                BackgroundColor = options.CancelDeleteBackgroundColor,
                TextColor = options.CancelDeleteTextColor
            };
        }
    }
}

