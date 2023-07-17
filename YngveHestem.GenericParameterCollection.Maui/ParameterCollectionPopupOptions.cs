using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui
{
    public class ParameterCollectionPopupOptions
    {
        /// <summary>
        /// The options for the Cancel-button. If null the text will be "Cancel" and the rest will be based on the CancelDelete-options from the inputted options.
        /// </summary>
        public LabelOptions CancelButtonOptions = null;

        /// <summary>
        /// The options for the Cancel-button. If null the text will be "Submit" and the rest will be based on the SubmitAdd-options from the inputted options.
        /// </summary>
        public LabelOptions SubmitButtonOptions = null;

        /// <summary>
        /// Should the value be validated before returning? If this is set to true it will not allow returning a value before everything is valid.
        /// </summary>
        public bool Validate = true;

        /// <summary>
        /// If validation fails, this text will be the title on the popup that appears. 
        /// </summary>
        public string ValidationFailedTitle = "Validation failed";

        /// <summary>
        /// If validation fails, this text will be the message on the popup that appears. 
        /// </summary>
        public string ValidationFailedMessage = "One or more values has validation errors. You can not submit without all values are as expected.";

        /// <summary>
        /// If validation fails, this text will be the text on the button to dismiss the "validation failed"-popup. 
        /// </summary>
        public string ValidationFailedButtonText = "OK";
    }
}