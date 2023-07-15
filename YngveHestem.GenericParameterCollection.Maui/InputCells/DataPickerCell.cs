using YngveHestem.FileTypeInfo;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class DataPickerCell : ParameterControlCell<byte[]>
    {
        private DataPickerView _view;

        /// <summary>
        /// Creates a new DataPickerCell
        /// </summary>
        /// <param name="parameter">The parameter to use.</param>
        /// <param name="onPreviewClicked">When the preview-button is clicked, what will happen. Inputs filepath, fileextension and the byte-date.</param>
        /// <param name="displayActionSheet">Display an action sheet is wished. The parameters are title, cancel, destruction and buttons.</param>
        /// <param name="displayAlert">Display an alert. The parameters are title, message, accept and cancel.</param>
        /// <param name="displayPrompt">Display a prompt. Parameters are title, message, accept and cancel.</param>
        /// <param name="selectButtonText">What will be said on the select-button.</param>
        /// <exception cref="ArgumentException"></exception>
        public DataPickerCell(Parameter parameter, ParameterCollectionViewOptions options, Page parentPage, string selectButtonText = "Select new resource") : base(parameter)
        {
            var dataPickerOptions = new DataPickerOptions
            {
                LabelOptions = options.ParameterNameLabelOptions(parameter.Key),
                Value = parameter.GetValue<byte[]>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                SelectButtonText = selectButtonText,
                SupportedFileTypes = options.FileTypeMappings.GetByExtension(options.SupportedFileExtensions).ToArray(),
                SupportedPreviews = options.BytesPreviews,
                SupportedWaysToGetBytes = options.SupportedWaysToGetBytes,
                ReadOnly = options.ReadOnly,
                SelectButtonOptions = options.SubmitAddOptions(string.Empty),
                InfoTextOptions = options.NormalTextOptions(string.Empty),
                BorderOptions = options.BorderOptions
            };

            if (parameter.HasAdditionalInfo())
            {
                var additionalInfo = parameter.GetAdditionalInfo();
                if (additionalInfo.HasKeyAndCanConvertTo(Extensions.PARAMETER_NAME_FILE_EXTENSION, typeof(string)))
                {
                    dataPickerOptions.FileExtension = additionalInfo.GetByKey<string>(Extensions.PARAMETER_NAME_FILE_EXTENSION);
                }

                if (additionalInfo.HasKeyAndCanConvertTo(Extensions.PARAMETER_NAME_FILE_PATH, typeof(string)))
                {
                    dataPickerOptions.FilePath = additionalInfo.GetByKey<string>(Extensions.PARAMETER_NAME_FILE_PATH);
                }
            }
            _view = new DataPickerView(dataPickerOptions, parentPage);
            View = _view;
        }



        /// <summary>
        /// Generetes and return new parameter with the correct name and evt. additionalInfo based on the changes done in the cell. Mark that this will not check if value is valid or not.
        /// </summary>
        /// <returns></returns>
        public override Parameter GetParameter()
        {
            var additionalInfo = new ParameterCollection();
            var additionalInfoFromParameter = _parameter.GetAdditionalInfo();

            if (additionalInfoFromParameter != null)
            {
                foreach (var aip in additionalInfoFromParameter)
                {
                    if (aip.Key == Extensions.PARAMETER_NAME_FILE_EXTENSION)
                    {
                        additionalInfo.Add(Extensions.PARAMETER_NAME_FILE_EXTENSION, _view.GetFileExtension(), false);
                    }
                    else if (aip.Key == Extensions.PARAMETER_NAME_FILE_PATH)
                    {
                        additionalInfo.Add(Extensions.PARAMETER_NAME_FILE_PATH, _view.GetFilePath(), false);
                    }
                    else
                    {
                        additionalInfo.Add(aip);
                    }
                }
            }

            if (!additionalInfo.HasKeyAndCanConvertTo(Extensions.PARAMETER_NAME_FILE_EXTENSION, typeof(string)))
            {
                additionalInfo.Add(Extensions.PARAMETER_NAME_FILE_EXTENSION, _view.GetFileExtension(), false);
            }
            if (!additionalInfo.HasKeyAndCanConvertTo(Extensions.PARAMETER_NAME_FILE_EXTENSION, typeof(string)))
            {
                additionalInfo.Add(Extensions.PARAMETER_NAME_FILE_EXTENSION, _view.GetFilePath(), false);
            }

            return new Parameter(_parameter.Key, _view.GetValue(), additionalInfo, _parameter.GetCustomConverters());
        }

        public override byte[] GetValue()
        {
            return ((DataPickerView)View).GetValue();
        }
    }
}

