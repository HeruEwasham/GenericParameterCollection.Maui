using System;
using YngveHestem.FileTypeInfo;

namespace YngveHestem.GenericParameterCollection.Maui.Bytes
{
    public class GetBytesFromUrl : IGetBytes
    {
        public string Name => "Get from URL";

        public async Task<BytesResult> GetBytes(IEnumerable<FileType> supportedFileTypes, Page parentPage)
        {
            var url = await parentPage.DisplayPromptAsync("Pick url", "Give the url you want to get data from", "Download from url", "Cancel");

            if (!string.IsNullOrWhiteSpace(url))
            {
                url = url.Trim();
                var types = supportedFileTypes.AllExtensions(true);
                var hasValidExtension = true;
                if (!types.Any(s => url.EndsWith(s, StringComparison.OrdinalIgnoreCase)))
                {
                    hasValidExtension = false;
                    if (!await parentPage.DisplayAlert("URL has not explicit file extension", "Url has not an explicit file extension in expected type. This might be because you have selected a url that has not an extension at the end (but will return valid data), but it can also be that you have selected an url that will not return valid data. Expected files normally has theese extensions: " + string.Join(", ", types) + Environment.NewLine + "Are you sure you want to download? The file downloaded might not be what we expect.", "Download", "Cancel"))
                    {
                        return null;
                    }
                }

                return new BytesResult(await new HttpClient().GetByteArrayAsync(url), url, hasValidExtension ? Path.GetExtension(url) : null);
            }

            return null;
        }

        public bool SupportsFileType(IEnumerable<FileType> fileTypes)
        {
            return true;    // Any filetypes can be supported
        }
    }
}

