using System;
namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	public class SwitchOptions
	{
        /// <summary>
        /// The value to set. Default value is false.
        /// </summary>
        public bool Value = false;

        /// <summary>
        /// Options for a label to show. If null, no label will be shown. Default is null (no label shown).
        /// </summary>
        public LabelOptions LabelOptions = null;

        /// <summary>
        /// Should the control only be ReadOnly. Default is false.
        /// </summary>
        public bool ReadOnly = false;

        /// <summary>
        /// The options for the "normal" text in the controls.
        /// </summary>
        public Color NormalBackgroundColor = Colors.Transparent;

        /// <summary>
        /// The options for the border.
        /// </summary>
        public BorderOptions BorderOptions = BorderOptions.Default;
    }
}

