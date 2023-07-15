using System.Collections.ObjectModel;
using YngveHestem.FileTypeInfo;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	internal class EditableListView<TControlType, TValue> : ControlView<List<TValue>> where TControlType : ControlView<TValue>
	{
        private EditableListOptions<TValue> _options { get; }
        private Page _parentPage { get; }
        private ObservableCollection<TControlType> _controlCollection { get; set; }

        public EditableListView(EditableListOptions<TValue> options, Page parentPage)
		{
            _options = options;
            _parentPage = parentPage;
            var rowDefinitions = new RowDefinitionCollection();
            var isWinUI = DeviceInfo.Current.Platform == DevicePlatform.WinUI;
            if (isWinUI)
            {
                rowDefinitions.Add(new RowDefinition(ParameterCollectionView.SingleRowHeight));
            }
            rowDefinitions.Add(new RowDefinition(GridLength.Star));
            var view = new Grid()
            {
                RowDefinitions = rowDefinitions
            };
            _controlCollection = new ObservableCollection<TControlType>();
			for (var i = 0; i < options.Value.Count; i++)
			{
                _controlCollection.Add((TControlType)CreateTControlType(options.Value[i], i + 1, options.ReadOnly));
			}
            var collectionView = new CollectionView { ItemsSource = _controlCollection };
            var addButton = new Button
            {
                Text = "Add",
                TextColor = _options.ParameterCollectionViewOptions.SubmitAddTextColor,
                FontFamily = _options.ParameterCollectionViewOptions.SubmitAddFont.Family,
                BackgroundColor = options.ParameterCollectionViewOptions.SubmitAddBackgroundColor,
                FontSize = _options.ParameterCollectionViewOptions.SubmitAddFont.Size,
                FontAttributes = _options.ParameterCollectionViewOptions.SubmitAddFont.GetFontAttributes(),
            };
            addButton.Clicked += OnAddButtonClicked;
            if (isWinUI)
            {
                view.Add(addButton, 0, 0);
            }
            else
            {
                collectionView.Header = addButton;
            }
            collectionView.ItemTemplate = new DataTemplate(() =>
            {
                var deleteButton = new SwipeItem
                {
                    Text = "Delete",
                    BackgroundColor = options.ParameterCollectionViewOptions.CancelDeleteBackgroundColor
                };
                deleteButton.Invoked += DeleteButton_Invoked;
                var deleteButtonMenuItem = new MenuFlyoutItem { Text = "Delete" };
                deleteButtonMenuItem.Clicked += DeleteButtonMenuItemClicked;
                var menu = new MenuFlyout
                {
                    { deleteButtonMenuItem }
                };
                var swipe = new SwipeView
                {
                    RightItems = new SwipeItems(new[] { deleteButton }),
                };
                swipe.SetBinding(ContentProperty, ".");
                FlyoutBase.SetContextFlyout(swipe, menu);
                return swipe;
            });
            view.Add(collectionView, 0, isWinUI ? 1 : 0);
            SetView(options.LabelOptions, view, options.BorderOptions);
        }

        private void DeleteButtonMenuItemClicked(object sender, EventArgs e)
        {
            var content = ((MenuFlyoutItem)sender).BindingContext as TControlType;
            _controlCollection.Remove(content);
        }

        private void DeleteButton_Invoked(object sender, EventArgs e)
        {
            var content = ((SwipeItem)sender).BindingContext as TControlType;
            _controlCollection.Remove(content);
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            _controlCollection.Add((TControlType)CreateTControlType(_options.DefaultValue, _controlCollection.Count + 1, _options.ReadOnly));
        }

        private object CreateTControlType(TValue value, int number, bool readOnly)
        {
            if (typeof(TControlType) == typeof(EntryView))
            {
                return new EntryView(new EntryEditorOptions
                {
                    Value = value.ToString(),
                    Keyboard = _options.ParameterCollectionViewOptions.KeyboardType,
                    TextValidationOptions = _options.ParameterCollectionViewOptions.TextValidation,
                    ReadOnly = readOnly,
                    NormalTextOptions = _options.NormalTextOptions
                });
            }
            else if (typeof(TControlType) == typeof(EditorView))
            {
                return new EditorView(new EntryEditorOptions
                {
                    Value = value.ToString(),
                    Keyboard = _options.ParameterCollectionViewOptions.KeyboardType,
                    TextValidationOptions = _options.ParameterCollectionViewOptions.TextValidation,
                    ReadOnly = readOnly,
                    NormalTextOptions = _options.NormalTextOptions,
                    BorderOptions = _options.BorderOptions
                });
            }
            else if (typeof(TControlType) == typeof(SwitchView))
            {
                return new SwitchView(new SwitchOptions
                {
                    Value = (bool)(object)value,
                    ReadOnly = readOnly,
                    NormalBackgroundColor = _options.NormalTextOptions.BackgroundColor,
                    BorderOptions = _options.BorderOptions
                });
            }
            else if (typeof(TControlType) == typeof(DateTimePickerView))
            {
                return new DateTimePickerView(new DateTimePickerOptions {
                    Value = (DateTime)(object)value,
                    PickOnlyDate = _options.ParameterType.HasValue && _options.ParameterType.Value == ParameterType.Date_IEnumerable,
                    MinimumDate = _options.ParameterCollectionViewOptions.MinDate,
                    MaximumDate = _options.ParameterCollectionViewOptions.MaxDate,
                    ReadOnly = readOnly,
                    NormalTextOptions = _options.NormalTextOptions,
                    BorderOptions = _options.BorderOptions
                });
            }
            else if (typeof(TControlType) == typeof(DataPickerView))
            {
                return new DataPickerView(new DataPickerOptions
                {
                    Value = (byte[])(object)value,
                    SupportedFileTypes = _options.ParameterCollectionViewOptions.FileTypeMappings.GetByExtension(_options.ParameterCollectionViewOptions.SupportedFileExtensions).ToArray(),
                    FileExtension = string.Empty,
                    FilePath = string.Empty,
                    ReadOnly = readOnly,
                    SelectButtonOptions = _options.SelectButtonOptions,
                    BorderOptions = _options.BorderOptions
                }, _parentPage);
            }
            else if (typeof(TControlType) == typeof(PickView))
            {
                var v = (Tuple<string, IEnumerable<string>>)(object)value;
                return new PickView(new PickOptions
                {
                    Value = v.Item1,
                    Options = v.Item2,
                    ReadOnly = readOnly,
                    NormalTextOptions = _options.NormalTextOptions,
                    BorderOptions = _options.BorderOptions
                });
            }
            else if (typeof(TControlType) == typeof(ParameterCollectionView))
            {
                return new ExpandableParameterCollectionView(number.ToString(), (ParameterCollection)(object)value, _parentPage, _options.ParameterCollectionViewOptions);
            }

            throw new ArgumentException("The " + nameof(TControlType) + " of type " + typeof(TControlType) + " is not supported.");
        }

        public override List<TValue> GetValue()
        {
            return _controlCollection.Select(c => c.GetValue()).ToList();
        }
    }
}

