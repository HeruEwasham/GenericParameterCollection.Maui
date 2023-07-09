using System;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
    public abstract class ControlView<TValue> : ContentView
    {
        private static readonly GridLength LabelLength = new GridLength(25);

        protected Parameter _parameter;

        public abstract TValue GetValue();

        /// <summary>
        /// Sets the view with automatic adding of label.
        /// </summary>
        /// <param name="options">The label options.</param>
        /// <param name="inputView">The main view to show/where input controls are.</param>
		protected void SetView(LabelOptions options, IView inputView, BorderOptions borderOptions)
        {
            var view = new Grid
            {
                RowDefinitions = new RowDefinitionCollection(new RowDefinition(LabelLength), new RowDefinition(GridLength.Star))
            };

            if (options != null)
            {
                view.Add(options.CreateLabel(), 0, 0);
            }

            view.Add(inputView, 0, 1);

            Content = borderOptions.CreateBorder(view);
        }
    }
}

