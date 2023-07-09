using YngveHestem.BytesPreview.Maui.Core;
using YngveHestem.FileTypeInfo;
using YngveHestem.GenericParameterCollection.Maui.Bytes;
using Font = Microsoft.Maui.Font;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
    public class DataPickerOptions
	{
        /// <summary>
        /// The value to set. Defaults to null
        /// </summary>
        public byte[] Value = null;

        /// <summary>
        /// Options for a label to show. If null, no label will be shown. Default is null (no label shown).
        /// </summary>
        public LabelOptions LabelOptions = null;

        /// <summary>
        /// The file path of current data. If not available to get, set to null. Default is null.
        /// </summary>
        public string FilePath = null;

        /// <summary>
        /// The file extension of the current data. If not available to get, set to null. Default is null.
        /// </summary>
        public string FileExtension = null;

        /// <summary>
        /// List of supported file extensions. If null, everything is supported.
        /// </summary>
        public FileType[] SupportedFileTypes = null;

        /// <summary>
        /// List of ways to get bytes. This can not be null and needs to contain at least one choice.
        /// </summary>
        public IGetBytes[] SupportedWaysToGetBytes = null;

        /// <summary>
        /// List of supported ways to preview some types of data.
        /// </summary>
        public IBytesPreview[] SupportedPreviews = null;

        /// <summary>
        /// The text to be shown on the button when the button to select a new source/resource.
        /// </summary>
        public string SelectButtonText = "Select new resource";

        /// <summary>
        /// The options on the button when the button to select a new source/resource.
        /// </summary>
        public LabelOptions SelectButtonOptions = null;

        /// <summary>
        /// The options on the text that will display the info about the byte-content and other informational text.
        /// </summary>
        public LabelOptions InfoTextOptions = null;

        /// <summary>
        /// Should the control only be ReadOnly. Default is false.
        /// </summary>
        public bool ReadOnly = false;

        /// <summary>
        /// The options for the border.
        /// </summary>
        public BorderOptions BorderOptions = BorderOptions.Default;
    }
}

