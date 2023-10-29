using YngveHestem.GenericParameterCollection.Maui.InputCells;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui;

public class ParameterCollectionView : ContentView
{
    private List<ViewCell> _cells { get; set; }
    private ParameterCollection _parameterCollection { get; set; }
    private Page _parentPage;

    internal static readonly GridLength SingleRowHeight = new GridLength(50, GridUnitType.Star);

    /// <summary>
    /// Creates a view that will show the ParameterCollection with the given options.
    /// </summary>
    /// <param name="parameterCollection">The ParameterCollection to show.</param>
    /// <param name="parentPage">The page this view is shown on.</param>
    /// <param name="options">The options for this view. If null, this will use the default options.</param>
    public ParameterCollectionView(ParameterCollection parameterCollection, Page parentPage, ParameterCollectionViewOptions options = null)
    {
        if (options == null)
        {
            options = new ParameterCollectionViewOptions();
        }
        _parentPage = parentPage;
        _parameterCollection = parameterCollection;
        _cells = new List<ViewCell>();
        var rowDefinitions = new List<RowDefinition>();
        foreach (var parameter in _parameterCollection)
        {
            var parameterOptions = options;
            if (parameterOptions.AdditionalInfoWillOverride && parameter.HasAdditionalInfo())
            {
                parameterOptions = ParameterCollectionViewOptions.CreateFromParameterCollection(parameter.GetAdditionalInfo(), parameterOptions);
            }
            var parameterContent = GetCellForParameter(parameter, parameterOptions);
            _cells.Add(parameterContent.Item1);
            rowDefinitions.Add(new RowDefinition(parameterContent.Item2));
        }
        var grid = new Grid
        {
            RowSpacing = 10,
            RowDefinitions = new RowDefinitionCollection(rowDefinitions.ToArray())
        };
        for (var i = 0; i < _cells.Count; i++)
        {
            grid.Add(_cells[i].View, 0, i);
        }
        Content = new ScrollView
        {
            Content = grid,
            VerticalOptions = LayoutOptions.Fill,
            VerticalScrollBarVisibility = ScrollBarVisibility.Always,
            
        };
	}

    /// <summary>
    /// Get the current value. If anything has been changed in the view. The returned ParameterCollection will reflect that.
    /// </summary>
    /// <param name="validate">Will you we shall validate it first? If this is true and any value is not seen as valid, it will return null.</param>
    /// <returns></returns>
    public ParameterCollection GetParameterCollection(bool validate = true)
    {
        var parameters = new ParameterCollection();

        foreach (var cell in _cells)
        {
            var parameter = GetParameterFromCell(cell);
            if (validate && !parameter.IsValid())
            {
                return null;
            }
            parameters.Add(parameter);
        }

        return parameters;
    }

    private Parameter GetParameterFromCell(Cell cell)
    {
        return ((IParameterCell)cell).GetParameter();
    }

    private Tuple<ViewCell, GridLength> GetCellForParameter(Parameter parameter, ParameterCollectionViewOptions options)
    {
        if (parameter.Type == ParameterType.String || parameter.Type == ParameterType.Int || parameter.Type == ParameterType.Decimal)
        {
            return new (new InputCells.EntryCell(parameter, options), SingleRowHeight);
        }
        else if (parameter.Type == ParameterType.Bool)
        {
            return new (new InputCells.SwitchCell(parameter, options), SingleRowHeight);
        }
        else if (parameter.Type == ParameterType.String_Multiline)
        {
            return new (new EditorCell(parameter, options), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.Date || parameter.Type == ParameterType.DateTime)
        {
            return new (new DateTimePickerCell(parameter, options), SingleRowHeight);
        }
        else if (parameter.Type == ParameterType.Bytes)
        {
            return new (new DataPickerCell(parameter, options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.Enum)
        {
            if (options.EnumSelection == SelectControl.SelectFromList)
            {
                return new(new SelectFromListCell(parameter, options), new GridLength(SingleRowHeight.Value / 1.5 * parameter.GetChoices().ToArray().Length));
            }

            return new(new PickCell(parameter, options), SingleRowHeight);
        }
        else if (parameter.Type == ParameterType.SelectOne)
        {
            if (options.SingleSelection == SelectControl.SelectFromList)
            {
                return new(new SelectFromListCell(parameter, options), new GridLength(SingleRowHeight.Value / 1.5 * parameter.GetChoices().ToArray().Length));
            }

            return new(new PickCell(parameter, options), SingleRowHeight);
        }
        else if (parameter.Type == ParameterType.ParameterCollection)
        {
            return new (new InputCells.ParameterCollectionView(parameter, options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.SelectMany)
        {
            return new (new SelectFromListCell(parameter, options), new GridLength(SingleRowHeight.Value / 1.5 * parameter.GetChoices().ToArray().Length));
        }
        else if (parameter.Type == ParameterType.String_IEnumerable)
        {
            return new(new EditableListCell<EntryView, string>(parameter, string.Empty, options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.Int_IEnumerable)
        {
            return new(new EditableListCell<EntryView, string>(parameter, "0", options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.Decimal_IEnumerable)
        {
            return new (new EditableListCell<EntryView, string>(parameter, "0.0", options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.Bool_IEnumerable)
        {
            return new (new EditableListCell<SwitchView, bool>(parameter, false, options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.String_Multiline_IEnumerable)
        {
            return new (new EditableListCell<EditorView, string>(parameter, string.Empty, options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.Date_IEnumerable
            || parameter.Type == ParameterType.DateTime_IEnumerable)
        {
            return new (new EditableListCell<DateTimePickerView, DateTime>(parameter, DateTime.Now, options, _parentPage), GridLength.Auto);
        }
        else if (parameter.Type == ParameterType.ParameterCollection_IEnumerable)
        {
            return new (new EditableListCell<ExpandableParameterCollectionView, ParameterCollection>(parameter, parameter.GetValue<ParameterCollection[]>()[0], options, _parentPage), GridLength.Auto);
        }
        else
        {
            throw new ArgumentException("Parameter is of type " + parameter.Type + ". This is not currently supported by " + nameof(ParameterCollectionView), nameof(parameter));
        }
    }
}
