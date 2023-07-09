namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
    public class DateTimePickerOptions
    {
        /// <summary>
        /// The value to set. Defaults to DateTime.Now
        /// </summary>
        public DateTime Value = DateTime.Now;

        /// <summary>
        /// Options for a label to show. If null, no label will be shown. Default is null (no label shown).
        /// </summary>
        public LabelOptions LabelOptions = null;

        /// <summary>
        /// Should the picker only use a date-picker (true), or should you also be able to set the time (false). Default is false.
        /// </summary>
        public bool PickOnlyDate = false;

        /// <summary>
        /// The MinimumDate. Defaults to 1900-01-01.
        /// </summary>
        public DateTime MinimumDate = new DateTime(1900, 01, 01);

        /// <summary>
        /// The MaximumDate. Defaults to 2100-12-31.
        /// </summary>
        public DateTime MaximumDate = new DateTime(2100, 12, 31);

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