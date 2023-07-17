using YngveHestem.BytesPreview.Maui.Core;
using YngveHestem.FileTypeInfo;
using YngveHestem.GenericParameterCollection.Maui.Bytes;
using YngveHestem.GenericParameterCollection.Maui.InputViews;
using Font = Microsoft.Maui.Font;

namespace YngveHestem.GenericParameterCollection.Maui
{
	public class ParameterCollectionViewOptions
	{
        /// <summary>
        /// Will additional parameters on a parameter override theese options if set (example, if a parameter has "readOnly" parameter set, should this override the readOnly-parameter set here).
        /// </summary>
        public bool AdditionalInfoWillOverride = true;

        /// <summary>
        /// Convert the parameter name to a human readable format. If set to false, the name will be shown as written, while if set to true, it will be altered to be read easily by a human, like setting first character to an upper character.
        /// </summary>
        public bool ShowParameterNameAsHumanReadable = true;

        /// <summary>
        /// Should all controls be readOnly as default.
        /// </summary>
        public bool ReadOnly = false;

        /// <summary>
        /// Font used on text.
        /// </summary>
        public Font NormalFont = Font.Default;

        /// <summary>
        /// Font used on the parameter names.
        /// </summary>
        public Font ParameterNameFont = Font.SystemFontOfWeight(FontWeight.Bold, FontSlant.Default, Font.Default.AutoScalingEnabled);

        /// <summary>
        /// Font used on submit or add buttons text.
        /// </summary>
        public Font SubmitAddFont = Font.Default;

        /// <summary>
        /// Font used on cancel or delete buttons text.
        /// </summary>
        public Font CancelDeleteFont = Font.Default;

        /// <summary>
        /// Color used on text.
        /// </summary>
        public Color NormalTextColor = Colors.Black;

        /// <summary>
        /// Color used on parameter names text.
        /// </summary>
        public Color ParameterNameTextColor = Colors.Black;

        /// <summary>
        /// Color used on submit or add buttons text.
        /// </summary>
        public Color SubmitAddTextColor = Colors.Black;

        /// <summary>
        /// Color used on cancel or delete buttons text.
        /// </summary>
        public Color CancelDeleteTextColor = Colors.Black;

        /// <summary>
        /// Color used on control background.
        /// </summary>
        public Color NormalBackgroundColor = Colors.Transparent;

        /// <summary>
        /// Color used on parameter names background.
        /// </summary>
        public Color ParameterNameBackgroundColor = Colors.Transparent;

        /// <summary>
        /// Color used on submit or add buttons background.
        /// </summary>
        public Color SubmitAddBackgroundColor = Colors.LimeGreen;

        /// <summary>
        /// Color used on cancel or delete buttons background.
        /// </summary>
        public Color CancelDeleteBackgroundColor = Colors.Red;

        /// <summary>
        /// The lowest date to be selected in appropiate controls.
        /// </summary>
        public DateTime MinDate = new DateTime(1900, 01, 01);

        // <summary>
        /// The maximum date to be selected in appropiate controls.
        /// </summary>
        public DateTime MaxDate = new DateTime(2100, 12, 31);

        /// <summary>
        /// The control/method to use when selecting an enum-value.
        /// </summary>
        public SelectControl EnumSelection = SelectControl.Picker;

        /// <summary>
        /// The control/method to use when selecting a single selection from a list of choices.
        /// </summary>
        public SelectControl SingleSelection = SelectControl.Picker;

        /// <summary>
        /// The keyboard-type to use when nothing is specified. This will not be applicable to numbers.
        /// </summary>
        public Keyboard KeyboardType = Keyboard.Default;

        /// <summary>
        /// The validation to use on strings when nothing is specified.
        /// </summary>
        public TextValidationOptions TextValidation = new TextValidationOptions();

        /// <summary>
        /// Defines what types of file extensions is supported when selecting files for ParameterType.Bytes. All must have a leading .
        /// Empty string[] means all types supported/no filter added.
        /// </summary>
        public string[] SupportedFileExtensions = null;

        /// <summary>
        /// List of different file types and mappings between extensions, UTType (UTI) and mime-types. All file extensions in SupportedFileExtensions must be defined here to be supported. Default value is all the values that is defined in the library used. Check for yourself if you need to add your own values.
        /// </summary>
        public FileType[] FileTypeMappings = FileTypes.Types;

        /// <summary>
        /// List of different previews for bytes.
        /// </summary>
        public IBytesPreview[] BytesPreviews = null;

        /// <summary>
        /// List of ways to get bytes. This can not be null and needs to contain at least one choice. Default is only pick from url as this is the only one that don't need additional approvals.
        /// </summary>
        public IGetBytes[] SupportedWaysToGetBytes = new IGetBytes[] { new GetBytesFromUrl() };

        /// <summary>
        /// Options that defines how the borders should be defined.
        /// </summary>
        public BorderOptions BorderOptions = BorderOptions.Default;

        /// <summary>
        /// For ParameterType.String, should a FolderPicker-Button be shown besides the text-input, as an option for getting input.
        /// </summary>
        public bool ShowFolderPicker = false;

        /// <summary>
        /// If the ShowFolderPicker is shown, should the text-field be readOnly or not.
        /// </summary>
        public bool TextReadOnlyWhenPickerIsShown = false;

        /// <summary>
        /// What should the text on the Add-buttons be.
        /// </summary>
        public string AddText = "Add";

        /// <summary>
        /// What should the text on the Cancel-button be.
        /// </summary>
        public string CancelText = "Cancel";

        /// <summary>
        /// What should the text on the Delete-button be.
        /// </summary>
        public string DeleteText = "Delete";

        /// <summary>
        /// What should the text before the number of bytes is shown when getting bytes be.
        /// </summary>
        public string ByteSizeText = "Selected item has size: ";

        /// <summary>
        /// What should the text before the file name is shown when getting bytes be.
        /// </summary>
        public string FilenameText = "Filename: ";

        /// <summary>
        /// What should the text to display when preview of byte-content is not available be.
        /// </summary>
        public string PreviewOfThisContentNotAvailableText = "Preview of this content not available.";

        /// <summary>
        /// What should the text on the PickBytes-button be.
        /// </summary>
        public string PickBytesText = "Select new resource";

        /// <summary>
        /// What should the text on the PickFolder-button be.
        /// </summary>
        public string PickFolderText = "Pick folder";

        public static ParameterCollectionViewOptions CreateCopy(ParameterCollectionViewOptions options)
        {
            return new ParameterCollectionViewOptions
            {
                AdditionalInfoWillOverride = options.AdditionalInfoWillOverride,
                ShowParameterNameAsHumanReadable = options.ShowParameterNameAsHumanReadable,
                ReadOnly = options.ReadOnly,
                NormalFont = options.NormalFont,
                ParameterNameFont = options.ParameterNameFont,
                SubmitAddFont = options.SubmitAddFont,
                CancelDeleteFont = options.CancelDeleteFont,
                NormalTextColor = options.NormalTextColor,
                ParameterNameTextColor = options.ParameterNameTextColor,
                SubmitAddTextColor = options.SubmitAddTextColor,
                CancelDeleteTextColor = options.CancelDeleteTextColor,
                NormalBackgroundColor = options.NormalBackgroundColor,
                ParameterNameBackgroundColor = options.ParameterNameBackgroundColor,
                SubmitAddBackgroundColor = options.SubmitAddBackgroundColor,
                CancelDeleteBackgroundColor = options.CancelDeleteBackgroundColor,
                MinDate = options.MinDate,
                MaxDate = options.MaxDate,
                EnumSelection = options.EnumSelection,
                SingleSelection = options.SingleSelection,
                KeyboardType = options.KeyboardType,
                TextValidation = options.TextValidation,
                SupportedFileExtensions = options.SupportedFileExtensions,
                BytesPreviews = options.BytesPreviews,
                SupportedWaysToGetBytes = options.SupportedWaysToGetBytes,
                FileTypeMappings = options.FileTypeMappings,
                BorderOptions = options.BorderOptions,
                ShowFolderPicker = options.ShowFolderPicker,
                TextReadOnlyWhenPickerIsShown = options.TextReadOnlyWhenPickerIsShown,
                AddText = options.AddText,
                CancelText = options.CancelText,
                DeleteText = options.DeleteText,
                ByteSizeText = options.ByteSizeText,
                FilenameText = options.FilenameText,
                PreviewOfThisContentNotAvailableText = options.PreviewOfThisContentNotAvailableText,
                PickBytesText = options.PickBytesText,
                PickFolderText = options.PickFolderText
            };
        }

        /// <summary>
        /// Creates a copy from a list of parameters.
        /// </summary>
        /// <param name="parameters">The parameters</param>
        /// <param name="defaultOptions">A list of options to use if correct parameter is not found. if this is null, the default parameter is used.</param>
        /// <returns></returns>
        public static ParameterCollectionViewOptions CreateFromParameterCollection(ParameterCollection parameters, ParameterCollectionViewOptions defaultOptions = null)
        {
            var result = new ParameterCollectionViewOptions();
            if (defaultOptions != null)
            {
                result = CreateCopy(defaultOptions);
            }

            if (parameters != null)
            {
                if (parameters.HasKeyAndCanConvertTo("humanReadable", typeof(bool)))
                {
                    result.ShowParameterNameAsHumanReadable = parameters.GetByKey<bool>("humanReadable");
                }

                if (parameters.HasKeyAndCanConvertTo("readOnly", typeof(bool)))
                {
                    result.ReadOnly = parameters.GetByKey<bool>("readOnly");
                }

                if (parameters.HasKeyAndCanConvertTo("minDate", typeof(DateTime)))
                {
                    result.MinDate = parameters.GetByKey<DateTime>("minDate");
                }

                if (parameters.HasKeyAndCanConvertTo("maxDate", typeof(DateTime)))
                {
                    result.MaxDate = parameters.GetByKey<DateTime>("maxDate");
                }

                if (parameters.HasKeyAndCanConvertTo("enumSelection", typeof(SelectControl)))
                {
                    result.EnumSelection = parameters.GetByKey<SelectControl>("enumSelection");
                }

                if (parameters.HasKeyAndCanConvertTo("singleSelection", typeof(SelectControl)))
                {
                    result.SingleSelection = parameters.GetByKey<SelectControl>("singleSelection");
                }

                if (parameters.HasKeyAndCanConvertTo("keyboard", typeof(Keyboard), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.KeyboardType = parameters.GetByKey<Keyboard>("keyboard", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("validation", typeof(TextValidationOptions), Extensions.CUSTOM_PARAMETER_CONVERTERS))
                {
                    result.TextValidation = parameters.GetByKey<TextValidationOptions>("validation", Extensions.CUSTOM_PARAMETER_CONVERTERS);
                }

                if (parameters.HasKeyAndCanConvertTo("supportedExtensions", typeof(string[])))
                {
                    result.SupportedFileExtensions = parameters.GetByKey<string[]>("supportedExtensions");
                }

                if (parameters.HasKeyAndCanConvertTo("borderOptions", typeof(ParameterCollection)))
                {
                    result.BorderOptions = BorderOptions.CreateFromParameterCollection(parameters.GetByKey<ParameterCollection>("borderOptions"), defaultOptions.BorderOptions);
                }

                if (parameters.HasKeyAndCanConvertTo("showFolderPicker", typeof(bool)))
                {
                    result.ShowFolderPicker = parameters.GetByKey<bool>("showFolderPicker");
                }

                if (parameters.HasKeyAndCanConvertTo("textReadOnly", typeof(bool)))
                {
                    result.TextReadOnlyWhenPickerIsShown = parameters.GetByKey<bool>("textReadOnly");
                }

                if (parameters.HasKeyAndCanConvertTo("addText", typeof(string)))
                {
                    result.AddText = parameters.GetByKey<string>("addText");
                }

                if (parameters.HasKeyAndCanConvertTo("cancelText", typeof(string)))
                {
                    result.CancelText = parameters.GetByKey<string>("cancelText");
                }

                if (parameters.HasKeyAndCanConvertTo("deleteText", typeof(string)))
                {
                    result.DeleteText = parameters.GetByKey<string>("deleteText");
                }

                if (parameters.HasKeyAndCanConvertTo("byteSizeText", typeof(string)))
                {
                    result.ByteSizeText = parameters.GetByKey<string>("byteSizeText");
                }

                if (parameters.HasKeyAndCanConvertTo("filenameText", typeof(string)))
                {
                    result.FilenameText = parameters.GetByKey<string>("filenameText");
                }

                if (parameters.HasKeyAndCanConvertTo("previewContentNotAvailableText", typeof(string)))
                {
                    result.PreviewOfThisContentNotAvailableText = parameters.GetByKey<string>("previewContentNotAvailableText");
                }

                if (parameters.HasKeyAndCanConvertTo("pickBytesText", typeof(string)))
                {
                    result.PickBytesText = parameters.GetByKey<string>("pickBytesText");
                }

                if (parameters.HasKeyAndCanConvertTo("pickFolderText", typeof(string)))
                {
                    result.PickFolderText = parameters.GetByKey<string>("pickFolderText");
                }
            }
            return result;
        }
    }
}

