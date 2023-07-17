using CommunityToolkit.Maui.Views;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui
{
    public class ParameterCollectionPopup : Popup
	{
        private ParameterCollectionView _view;

        /// <summary>
        /// Creates a popup that will show the ParameterCollection with the given options and a button to close and one button to submit and get the new ParameterCollection.
        /// </summary>
        /// <param name="parameterCollection">The ParameterCollection to show.</param>
        /// <param name="parentPage">The page this view is shown on.</param>
        /// <param name="options">The options for this view. If null, this will use the default options.</param>
        /// <param name="popupOptions">Options specified to the popup.</param>
        public ParameterCollectionPopup(ParameterCollection parameterCollection, Page parentPage, ParameterCollectionViewOptions options = null, ParameterCollectionPopupOptions popupOptions = null)
		{
            if (options == null)
            {
                options = new ParameterCollectionViewOptions();
            }
            if (popupOptions == null)
            {
                popupOptions = new ParameterCollectionPopupOptions();
            }
            if (popupOptions.CancelButtonOptions == null)
            {
                popupOptions.CancelButtonOptions = options.CancelDeleteOptions("Cancel");
            }
            if (popupOptions.SubmitButtonOptions == null)
            {
                popupOptions.SubmitButtonOptions = options.SubmitAddOptions("Submit");
            }
            _view = new ParameterCollectionView(parameterCollection, parentPage, options);
            var cancelButton = popupOptions.CancelButtonOptions.CreateButton();
            cancelButton.Clicked += (s, e) => { Close(); };
            var submitButton = popupOptions.SubmitButtonOptions.CreateButton();
            submitButton.Clicked += (s, e) =>
            {
                var value = _view.GetParameterCollection(popupOptions.Validate);
                if (value != null)
                {
                    Close(value);
                }
                else
                {
                    parentPage.DisplayAlert(popupOptions.ValidationFailedTitle, popupOptions.ValidationFailedMessage, popupOptions.ValidationFailedButtonText);
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

