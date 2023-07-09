namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal abstract class ParameterControlCell<TValue> : ViewCell, IParameterCell
    {
        protected Parameter _parameter;

        public ParameterControlCell(Parameter parameter)
        {
            if (!parameter.CanBeConvertedTo(typeof(TValue), Extensions.CUSTOM_PARAMETER_CONVERTERS))
            {
                throw new ArgumentException($"Parameter {parameter.Key} of type {parameter.Type} need to be converted to type {typeof(TValue)}, but it could not.", nameof(parameter));
            }
            _parameter = parameter;
        }

        public virtual Parameter GetParameter()
        {
            if (_parameter == null)
            {
                throw new Exception("Parameter expected when using " + nameof(GetParameter) + ", but none where found.");
            }
            return new Parameter(_parameter.Key, GetValue(), _parameter.Type, _parameter.GetAdditionalInfo(), _parameter.GetCustomConverters(), Extensions.CUSTOM_PARAMETER_CONVERTERS);
        }

        public string GetParameterKey()
        {
            if (_parameter == null)
            {
                throw new Exception("Parameter expected when using " + nameof(GetParameterKey) + ", but none where found.");
            }
            return _parameter.Key;
        }

        public abstract TValue GetValue();
    }
}