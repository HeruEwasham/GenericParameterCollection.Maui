using System;
using YngveHestem.FileTypeInfo;

namespace YngveHestem.GenericParameterCollection.Maui.Bytes
{
	public interface IGetBytes
	{
		/// <summary>
		/// This should be a descriptive, short name to what it does. The name also need to be unique as it is used to get what the user selects.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Get bytes and other info.
		/// </summary>
		/// <param name="supportedFileTypes">The file types that should be allowed. This can be null, and then it means every file type is allowed.</param>
		/// <param name="parentPage">The page we are on. This can be used to add popups with input if needed.</param>
		/// <returns></returns>
		Task<BytesResult> GetBytes(IEnumerable<FileType> supportedFileTypes, Page parentPage);

		/// <summary>
		/// Returns true if at least one of the inputted FileTypes is supported. This should be used to determine if it is necessarry to list this as an option at all (for example, it is not necessarry to list pick photo from camera-roll of no pictures can be returned as any of theese types.
		/// </summary>
		/// <param name="fileTypes">The filetypes to check. If null, this should be considered as meaning any file type, and then most likely return true.</param>
		/// <returns></returns>
		bool SupportsFileType(IEnumerable<FileType> fileTypes);
	}
}

