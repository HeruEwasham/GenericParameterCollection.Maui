using System;
using CommunityToolkit.Maui.Behaviors;

namespace YngveHestem.GenericParameterCollection.Maui.InputViews
{
	public class TextValidationOptions
	{
		/// <summary>
		/// The regex to match against.
		/// </summary>
		public string ValidationRegex = ".*";

		/// <summary>
		/// The color to show when input is valid.
		/// </summary>
		public Color ValidColor = Colors.Green;

        /// <summary>
        /// The color to show when input is invalid.
        /// </summary>
        public Color InvalidColor = Colors.Red;

		/// <summary>
		/// Select which type of property that should be changed to reflect the validation-status.
		/// </summary>
		public PropertyType PropertyToShowStatus;

		/// <summary>
		/// Select flags for how it should be validated.
		/// </summary>
		public ValidationFlags ValidationFlags = ValidationFlags.ValidateOnValueChanged;
    }
}

