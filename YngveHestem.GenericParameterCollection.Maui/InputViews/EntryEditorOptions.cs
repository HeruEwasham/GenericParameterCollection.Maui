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
    }
}

