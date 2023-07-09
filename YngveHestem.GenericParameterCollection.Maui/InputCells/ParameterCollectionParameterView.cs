using System;
using CommunityToolkit.Maui.Views;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class ParameterCollectionView : ParameterControlCell<ParameterCollection>
    {
        private ExpandableParameterCollectionView _view;

        public ParameterCollectionView(Parameter parameter, ParameterCollectionViewOptions options, Page parentPage) : base(parameter)
        {
            _view = new ExpandableParameterCollectionView(options.ShowParameterNameAsHumanReadable ? parameter.Key.FirstCharToUpper() : parameter.Key,
                _parameter.GetValue<ParameterCollection>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                parentPage,
                options);
            View = _view;
        }

        public override ParameterCollection GetValue()
        {
            return _view.GetValue();
        }
    }
}

