using System;
namespace YngveHestem.GenericParameterCollection.Maui.InputCells
{
    internal interface IParameterCell
    {
        /// <summary>
        /// Generetes and return new parameter with the correct name and evt. additionalInfo based on the changes done in the cell. Mark that this will not check if value is valid or not.
        /// </summary>
        /// <returns></returns>
        Parameter GetParameter();

        /// <summary>
        /// Get the key for the parameter.
        /// </summary>
        /// <returns></returns>
        string GetParameterKey();
    }
}

