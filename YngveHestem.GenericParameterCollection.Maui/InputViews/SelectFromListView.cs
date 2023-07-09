using System.Collections.ObjectModel;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	public class SelectFromListView : ControlView<Tuple<IEnumerable<string>, IEnumerable<string>>>
	{
        private SelectFromListOptions _options { get; set; }
        private CollectionView _view { get; set; }

        public SelectFromListView(SelectFromListOptions options)
		{
            _options = options;
            var selectedItems = new List<object>();
            if (options.Value != null)
            {
                selectedItems.AddRange(options.Value);
            }
            var content = new ObservableCollection<string>(options.Options);
            _view = new CollectionView {
                ItemsSource = content,
                SelectionMode = options.SelectionMode,
                ItemTemplate = new DataTemplate(() =>
                {
                    var label = _options.LabelOptions.CreateLabel();
                    label.SetBinding(Label.TextProperty, ".");
                    return label;
                }),
                IsEnabled = !options.ReadOnly
            };
            _view.SelectedItems = selectedItems;
            SetView(options.LabelOptions, _view, options.BorderOptions);
        }

        public override Tuple<IEnumerable<string>, IEnumerable<string>> GetValue()
        {
            return new Tuple<IEnumerable<string>, IEnumerable<string>>(_view.SelectedItems.Distinct().Select(o => o.ToString()), _options.Options);
        }
    }
}

