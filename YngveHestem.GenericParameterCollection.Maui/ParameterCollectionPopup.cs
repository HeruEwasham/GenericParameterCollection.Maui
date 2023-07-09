using System;
using CommunityToolkit.Maui.Views;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui
{
	public class ParameterCollectionPopup : Popup
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

        private ParameterCollectionView _view;

		public ParameterCollectionPopup(ParameterCollection parameterCollection, Page parentPage, ParameterCollectionViewOptions options = null)
		{
            if (options == null)
            {
                options = new ParameterCollectionViewOptions();
            }
            if (CancelButtonOptions == null)
            {
                CancelButtonOptions = options.CancelDeleteOptions("Cancel");
            }
            if (SubmitButtonOptions == null)
            {
                SubmitButtonOptions = options.SubmitAddOptions("Submit");
            }
            _view = new ParameterCollectionView(parameterCollection, parentPage, options);
            var cancelButton = CancelButtonOptions.CreateButton();
            cancelButton.Clicked += (s, e) => { Close(); };
            var submitButton = SubmitButtonOptions.CreateButton();
            submitButton.Clicked += (s, e) =>
            {
                var value = _view.GetParameterCollection(Validate);
                if (value != null)
                {
                    Close(value);
                }
                else
                {
                    parentPage.DisplayAlert(ValidationFailedTitle, ValidationFailedMessage, ValidationFailedButtonText);
                }
            };
            var grid = new Grid
            {
                RowDefinitions = new RowDefinitionCollection(new RowDefinition(50), new RowDefinition(50), new RowDefinition(GridLength.Star))
            };
            grid.Add(_view, 0, 2);
            grid.Add(submitButton, 0, 0);
            grid.Add(cancelButton, 0, 1);
            Content = grid;
            CanBeDismissedByTappingOutsideOfPopup = false;
            //Size = new Size(DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height);
		}
	}
}

