using System;
namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	public class EntryEditorOptions
	{
        /// <summary>
        /// The value to set. Default value is empty string.
        /// </summary>
        public string Value = string.Empty;

        /// <summary>
        /// Options for a label to show. If null, no label will be shown. Default is null (no label shown).
        /// </summary>
        public LabelOptions LabelOptions = null;

        /// <summary>
        /// Options for validation. If null, no validation will be done. Default is null (no validation).
        /// </summary>
        public TextValidationOptions TextValidationOptions = null;

        /// <summary>
        /// The keyboard type to use.
        /// </summary>
        public Keyboard Keyboard = Keyboard.Default;

        /// <summary>
        /// Should the control only be ReadOnly. Default is false.
        /// </summary>
        public bool ReadOnly = false;

        /// <summary>
        /// The options for the "normal" text in the controls.
        /// </summary>
        public LabelOptions NormalTextOptions = null;

        /// <summary>
        /// The options for the border.
        /// </summary>
        public BorderOptions BorderOptions = BorderOptions.Default;

        /// <summary>
        /// Should a FolderPicker-button be shown besides the text-input, as an option for getting input.
        /// </summary>
        public bool ShowFolderPicker = false;

        /// <summary>
        /// If the ShowFolderPicker is shown, should the text-field be readOnly or not.
        /// </summary>
        public bool TextReadOnlyWhenPickerIsShown = false;

        /// <summary>
        /// The text to display on the FolderPicker-button if shown.
        /// </summary>
        public string FolderPickerText = "Pick folder";
    }
}

