using System;
using YngveHestem.GenericParameterCollection.Maui.InputViews;

namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal class EditorCell : ParameterControlCell<string>
    {
        public EditorCell(Parameter parameter, ParameterCollectionViewOptions options) : base(parameter)
        {
            var editorOptions = new EntryEditorOptions
            {
                LabelOptions = options.CellTitleLabelOptions(parameter.Key),
                Value = parameter.GetValue<string>(Extensions.CUSTOM_PARAMETER_CONVERTERS),
                Keyboard = options.KeyboardType,
                TextValidationOptions = options.TextValidation,
                ReadOnly = options.ReadOnly,
                NormalTextOptions = options.NormalTextOptions(string.Empty),
                BorderOptions = options.BorderOptions
            };

            if (parameter.HasAdditionalInfo())
            {
                var additionalInfo = parameter.GetAdditionalInfo();
                if (additionalInfo.HasKeyAndCanConvertTo(Extensions.PARAMETER_NAME_VALIDATION_REGEX, typeof(string)))
                {
                    editorOptions.TextValidationOptions = new TextValidationOptions
                    {
                        ValidationRegex = additionalInfo.GetByKey<string>(Extensions.PARAMETER_NAME_VALIDATION_REGEX)
                    };
                }
            }

            View = new EditorView(editorOptions);
        }

        public override string GetValue()
        {
            return ((EditorView)View).GetValue();
        }
    }
}

