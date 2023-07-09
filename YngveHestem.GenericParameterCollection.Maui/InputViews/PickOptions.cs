using System;
namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	public class PickOptions
	{
        /// <summary>
        /// The value to set. This must be the same value as one of the values in the Options-list or null. Default value is null.
        /// </summary>
        public string Value = null;

        /// <summary>
        /// Options for a label to show. If null, no label will be shown. Default is null (no label shown).
        /// </summary>
        public LabelOptions LabelOptions = null;

        /// <summary>
        /// The different options to choose from. This value must be set if options should be shown.
        /// </summary>
        public IEnumerable<string> Options = null;

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

