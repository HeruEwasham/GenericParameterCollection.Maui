namespace MediaAndMetadataOrganiser.InputPages.InputViews;

public class DataPickerView : ContentView
{
    private Button _selectButton;
    private Button _previewButton;
    private byte[] _byteData;
    private string _filePath;
    private string _fileExtension;
    private Page _parentPage;

    public DataPickerView(DataPickerOptions options, Page parentPage)
    {
        var view = new VerticalStackLayout();
        if (options.LabelOptions != null)
        {
            view.Add(options.LabelOptions.CreateLabel());
        }

        _selectButton = new Button
        {
            Text = options.SelectButtonText
        };
        _selectButton.Clicked += OnSelectClicked;

        _previewButton = new Button
        {
            Text = "Show preview"
        };
        _previewButton.Clicked += OnPreviewClicked;

        _byteData = options.Value;
        _parentPage = parentPage;

        Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}

    public byte[] GetBytes()
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

    private async void OnPreviewClicked(object sender, EventArgs e)
    {
        await _parentPage.Navigation.PushModalAsync(new DataPreviewPage(_filePath, _fileExtension, _byteData));
    }

    private async void OnSelectClicked(object sender, EventArgs e)
    {
        var choicesToPickFrom = new List<string>();
        var fileTypes = new List<string>();

        if (fileTypes.Any(s => s == "image") || fileTypes.Any(s => InputPagesExtensions.IsImageExtension(s)))
        {
            choicesToPickFrom.Add(InputPagesExtensions.PICK_PHOTO_TEXT);
        }
        if (fileTypes.Any(s => s == "video") || fileTypes.Any(s => InputPagesExtensions.IsVideoExtension(s)))
        {
            choicesToPickFrom.Add(InputPagesExtensions.PICK_VIDEO_TEXT);
        }
        choicesToPickFrom.Add(InputPagesExtensions.PICK_FILE_TEXT);
        choicesToPickFrom.Add(InputPagesExtensions.PICK_URL_TEXT);

        var selectedChoice = await _parentPage.DisplayActionSheet("Pick file from", "Cancel", null, choicesToPickFrom.ToArray());

        if (selectedChoice == InputPagesExtensions.PICK_PHOTO_TEXT)
        {
            var file = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick an image."
            });
            if (file != null)
            {
                if (InputPagesExtensions.IsImageMimeType(file.ContentType))
                {
                    var s = await file.OpenReadAsync();
                    using (BinaryReader br = new BinaryReader(s))
                    {
                        _byteData = br.ReadBytes((int)s.Length);
                    }
                    _filePath = file.FullPath;
                    _fileExtension = Path.GetExtension(file.FileName);
                }
            }
        }
        else if (selectedChoice == InputPagesExtensions.PICK_VIDEO_TEXT)
        {
            var file = await MediaPicker.Default.PickVideoAsync(new MediaPickerOptions
            {
                Title = "Pick a video."
            });
            if (file != null)
            {
                if (InputPagesExtensions.IsVideoMimeType(file.ContentType))
                {
                    using (var s = await file.OpenReadAsync())
                    {
                        using (BinaryReader br = new BinaryReader(s))
                        {
                            _byteData = br.ReadBytes((int)s.Length);
                        }
                    }
                    _filePath = file.FullPath;
                    _fileExtension = Path.GetExtension(file.FileName);
                }
            }
        }
        else if (selectedChoice == InputPagesExtensions.PICK_FILE_TEXT)
        {
            FilePickerFileType filePickerFileTypes = null;

            if (fileTypes.All(s => s == "image" || InputPagesExtensions.IsImageExtension(s)))
            {
                filePickerFileTypes = FilePickerFileType.Images;
            }
            else if (fileTypes.All(s => s == "video" || InputPagesExtensions.IsVideoExtension(s)))
            {
                filePickerFileTypes = FilePickerFileType.Videos;
            }
            else if (fileTypes.All(s => s == ".jpg" || s == ".jpeg"))
            {
                filePickerFileTypes = FilePickerFileType.Jpeg;
            }
            else if (fileTypes.All(s => s == ".png"))
            {
                filePickerFileTypes = FilePickerFileType.Png;
            }
            else if (fileTypes.All(s => s == ".pdf"))
            {
                filePickerFileTypes = FilePickerFileType.Png;
            }

            try
            {
                var result = await FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
                {
                    PickerTitle = "Pick a file",
                    FileTypes = filePickerFileTypes != null ? filePickerFileTypes : null
                });
                if (result != null)
                {
                    if (fileTypes.Any())
                    {
                        if (!fileTypes.Any(s => result.FileName.EndsWith(s, StringComparison.OrdinalIgnoreCase)))
                        {
                            await _parentPage.DisplayAlert("Filetype not supported", "Filetype " + Path.GetExtension(result.FileName) + " is not expected here. Only filetypes with theese extensions are supported: " + string.Join(", ", fileTypes), "OK", null);
                            return;
                        }
                    }

                    using (var stream = await result.OpenReadAsync())
                    {
                        using (BinaryReader br = new BinaryReader(stream))
                        {
                            _byteData = br.ReadBytes((int)stream.Length);
                        }
                    }

                    _filePath = result.FullPath;
                    _fileExtension = Path.GetExtension(result.FileName);
                }
            }
            catch (Exception ex)
            {
                await _parentPage.DisplayAlert("Something went wrong", "Got error: " + ex.Message, "OK", null);
            }
        }
        else if (selectedChoice == InputPagesExtensions.PICK_URL_TEXT)
        {
            var url = await _parentPage.DisplayPromptAsync("Pick url", "Give the url you want to get data from", "Download from url", "Cancel");

            if (!string.IsNullOrWhiteSpace(url))
            {
                url = url.Trim();
                var hasValidExtension = true;
                if (!fileTypes.Any(s => url.EndsWith(s, StringComparison.OrdinalIgnoreCase)))
                {
                    hasValidExtension = false;
                    if (!await _parentPage.DisplayAlert("URL has not explicit file extension", "Url has not an explicit file extension in expected type. This might be because you have selected a url that has not an extension at the end (but will return valid data), but it can also be that you have selected an url that will not return valid data. Expected files normally has theese extensions: " + string.Join(", ", fileTypes) + Environment.NewLine + "Are you sure you want to download? The file downloaded might not be what we expect.", "Download", "Cancel"))
                    {
                        return;
                    }
                }

                _byteData = await new HttpClient().GetByteArrayAsync(url);
                _filePath = url;
                _fileExtension = hasValidExtension ? Path.GetExtension(url) : null;
            }
        }
    }
}
