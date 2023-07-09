using System;
using YngveHestem.FileTypeInfo;

namespace YngveHestem.GenericParameterCollection.Maui.Bytes
{
    public class GetBytesFromFilePicker : IGetBytes
    {
        public string Name => "Pick file";

        public async Task<BytesResult> GetBytes(IEnumerable<FileType> supportedFileTypes, Page parentPage)
        {
            try
            {
                var result = await FilePicker.Default.PickAsync(new Microsoft.Maui.Storage.PickOptions
                {
                    PickerTitle = "Pick a file",
                    FileTypes = GetFilePickerFileType(supportedFileTypes)
                });
                if (result != null)
                {
                    if (supportedFileTypes != null && supportedFileTypes.Any())
                    {
                        var supportedExtensions = supportedFileTypes.AllExtensions();
                        if (!supportedExtensions.Any(s => result.FileName.EndsWith(s, StringComparison.OrdinalIgnoreCase)))
                        {
                            await parentPage.DisplayAlert("Filetype not supported", "Filetype " + Path.GetExtension(result.FileName) + " is not expected here. Only filetypes with theese extensions are supported: " + string.Join(", ", supportedExtensions), "OK", null);
                            return null;
                        }
                    }

                    using (var stream = await result.OpenReadAsync())
                    {
                        using (BinaryReader br = new BinaryReader(stream))
                        {
                            return new BytesResult(br.ReadBytes((int)stream.Length), result.FullPath, Path.GetExtension(result.FileName));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await parentPage.DisplayAlert("Something went wrong", "Got error: " + ex.Message, "OK", null);
            }

            return null;
        }

        public bool SupportsFileType(IEnumerable<FileType> fileTypes)
        {
            return true;
        }

        private FilePickerFileType? GetFilePickerFileType(IEnumerable<FileType> fileTypes)
        {
            if (fileTypes == null)
            {
                return null;
            }
            var utTypes = fileTypes.AllUTTypes();
            var mimeTypes = fileTypes.AllMimeTypes();
            var extensions = fileTypes.AllExtensions();

            if (utTypes.Count == 0 && mimeTypes.Count == 0 && extensions.Count == 0)
            {
                return null;
            }

            return new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.iOS, utTypes }, // UTType values
                    { DevicePlatform.Android, mimeTypes }, // MIME type
                    { DevicePlatform.WinUI, extensions }, // file extension
                    { DevicePlatform.Tizen, new[] { "*/*" } },
                    { DevicePlatform.macOS, utTypes }, // UTType values
                });
        }
    }
}

