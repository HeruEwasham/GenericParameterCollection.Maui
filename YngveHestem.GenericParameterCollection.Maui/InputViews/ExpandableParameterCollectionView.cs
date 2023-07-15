using System;
using CommunityToolkit.Maui.Views;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	internal class ExpandableParameterCollectionView : ControlView<ParameterCollection>
	{
        private Expander _expander;

        public ExpandableParameterCollectionView(string headerText, ParameterCollection value, Page parentPage, ParameterCollectionViewOptions options)
		{
            _expander = new Expander
            {
                Header = options.ParameterNameLabelOptions(headerText).CreateLabel(),
                Content = new ParameterCollectionView(value, parentPage, options),
                IsExpanded = true,
            };

            Content = _expander;
        }

        public override ParameterCollection GetValue()
        {
            return ((ParameterCollectionView)_expander.Content).GetParameterCollection(false);
        }
    }
}

