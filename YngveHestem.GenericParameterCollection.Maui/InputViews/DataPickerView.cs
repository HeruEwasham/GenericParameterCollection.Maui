using YngveHestem.BytesPreview.Maui.Core;
using YngveHestem.FileTypeInfo;
using YngveHestem.GenericParameterCollection.Maui.Bytes;
using static System.Net.Mime.MediaTypeNames;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews;

internal class DataPickerView : ControlView<byte[]>
{
    private byte[] _byteData;
    private string _filePath;
    private string _fileExtension;
    private DataPickerOptions _options;
    private Page _parentPage;
    private string _labelString;

    public DataPickerView(DataPickerOptions options, Page parentPage)
    {
        if (options.SupportedWaysToGetBytes == null)
        {
            throw new ArgumentNullException(nameof(options.SupportedWaysToGetBytes));
        }
        if (options.SupportedWaysToGetBytes.Length == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(options.SupportedWaysToGetBytes), "We need at least one supported method to get bytes.");
        }

        _byteData = options.Value != null ? options.Value : new byte[0];
        _filePath = options.FilePath != null ? options.FilePath : string.Empty;
        _fileExtension = options.FileExtension != null ? options.FileExtension : string.Empty;
        _parentPage = parentPage;
        _labelString = options.LabelOptions.Text;
        _options = options;

        CreateAndSetView();
	}

    private void CreateAndSetView()
    {
        var view = new Grid();
        var row = 0;

        if (!_options.ReadOnly)
        {
            view.RowDefinitions.Add(new RowDefinition(50));
            var selectButton = _options.SelectButtonOptions.CreateButton();
            selectButton.Text = _options.SelectButtonText;
            selectButton.Clicked += OnSelectClicked;
            view.Add(selectButton, 0, row);
            row++;
        }

        view.RowDefinitions.Add(new RowDefinition(50));
        view.Add(_options.InfoTextOptions.CreateLabel("Selected item has size: " + _byteData.Length.GetSizeInMemory()), 0, row);
        
        row++;

        if (!string.IsNullOrWhiteSpace(_filePath))
        {
            view.RowDefinitions.Add(new RowDefinition(50));
            view.Add(_options.InfoTextOptions.CreateLabel("Filename: " + _filePath), 0, row);
            row++;
        }

        view.RowDefinitions.Add(new RowDefinition(100));
        view.Add(GetPreview(), 0, row);
        row++;

        SetView(_options.LabelOptions, view, _options.BorderOptions);
    }

    public override byte[] GetValue()
    {
        return _byteData;
    }

    public string GetFilePath()
    {
        return _filePath;
    }

    public string GetFileExtension()
    {
        return _fileExtension;
    }

    private async void OnSelectClicked(object sender, EventArgs e)
    {
        if (_options.SupportedWaysToGetBytes.Length > 1)
        {
            var selectedChoice = await _parentPage.DisplayActionSheet(_labelString, "Cancel", null, _options.SupportedWaysToGetBytes.Select(c => c.Name).ToArray());

            var result = await _options.SupportedWaysToGetBytes.First(c => c.Name == selectedChoice).GetBytes(_options.SupportedFileTypes, _parentPage);
            if (result != null)
            {
                _byteData = result.Bytes;
                _filePath = result.FilePath;
                _fileExtension = result.FileExtension;
                CreateAndSetView();
            }
        }
        else
        {
            var result = await _options.SupportedWaysToGetBytes[0].GetBytes(_options.SupportedFileTypes, _parentPage);

            if (result != null)
            {
                _byteData = result.Bytes;
                _filePath = result.FilePath;
                _fileExtension = result.FileExtension;
                CreateAndSetView();
            }
        }
    }

    private View GetPreview()
    {
        if (_options.SupportedPreviews != null)
        {
            var fileType = _options.SupportedFileTypes.GetByExtension(_fileExtension).FirstOrDefault();
            var prev = _options.SupportedPreviews.FirstOrDefault(sp => sp.CanPreviewBytes(fileType, _byteData));

            if (prev != null)
            {
                return prev.GetPreviewControl(fileType, _byteData);
            }
        }
        var label = _options.InfoTextOptions.CreateLabel();
        label.Text = "Preview of this content not available.";
        return label;
    }
}
