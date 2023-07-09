using System;
using YngveHestem.FileTypeInfo;

namespace YngveHestem.GenericParameterCollection.Maui.Bytes
{
    public class GetBytesFromCameraRollImage : IGetBytes
    {
        public string Name => "Pick image from camera roll";

        public async Task<BytesResult> GetBytes(IEnumerable<FileType> supportedFileTypes, Page parentPage)
        {
            var file = await MediaPicker.Default.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Pick an image."
            });
            if (file != null)
            {
                if (supportedFileTypes.GetByMimeType(file.ContentType).Any())
                {
                    var s = await file.OpenReadAsync();
                    using (BinaryReader br = new BinaryReader(s))
                    {
                        return new BytesResult(br.ReadBytes((int)s.Length), file.FullPath, Path.GetExtension(file.FileName));
                    }
                }
            }
        }

        public bool SupportsFileType(IEnumerable<FileType> fileTypes)
        {
            return fileTypes.GetByUTType("public.image").Any();
        }
    }
}

