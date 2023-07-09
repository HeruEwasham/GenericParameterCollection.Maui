using System;
namespace MediaAndMetadataOrganiser.InputPages.InputViews
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
        /// List of supported file extensions. The file types shall be with a leading dot.
        /// </summary>
        public List<string> SupportedFileTypes = new List<string>();

        /// <summary>
        /// The text to be shown on the button when the button to select a new source/resource.
        /// </summary>
        public string SelectButtonText = "Select new resource";
    }
}

