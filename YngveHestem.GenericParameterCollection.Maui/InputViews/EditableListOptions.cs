using System;
namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	public class EditableListOptions<TValue>
	{
        /// <summary>
        /// The value to set. This must be the same value as one of the values in the Options-list or null. Default value is null.
        /// </summary>
        public List<TValue> Value = null;

        /// <summary>
        /// The default value to set when for example adding a new value. Default value is the default value of TValue.
        /// </summary>
        public TValue DefaultValue = default;

        /// <summary>
        /// Options for a label to show. If null, no label will be shown. Default is null (no label shown).
        /// </summary>
        public LabelOptions LabelOptions = null;

        /// <summary>
        /// Options for ParameterCollectionView. Default is null.
        /// </summary>
        public ParameterCollectionViewOptions ParameterCollectionViewOptions = null;

        /// <summary>
        /// Get the ParameterType that is used. This defaults to null, as "not set".
        /// </summary>
        public ParameterType? ParameterType = null;

        /// <summary>
        /// Should the control only be ReadOnly. Default is false.
        /// </summary>
        public bool ReadOnly = false;

        /// <summary>
        /// The options for the "normal" text in the controls.
        /// </summary>
        public LabelOptions NormalTextOptions = null;

        /// <summary>
        /// The options on a select, add or similar button.
        /// </summary>
        public LabelOptions SelectButtonOptions = null;

        /// <summary>
        /// The options for the border.
        /// </summary>
        public BorderOptions BorderOptions = BorderOptions.Default;
    }
}

