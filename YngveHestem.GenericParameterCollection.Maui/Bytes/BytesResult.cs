using System;
namespace YngveHestem.GenericParameterCollection.Maui.Bytes
{
	public class BytesResult
	{
		/// <summary>
		/// The bytes.
		/// </summary>
		public byte[] Bytes { get; }

		/// <summary>
		/// The full file-path.
		/// </summary>
		public string FilePath { get; }

		/// <summary>
		/// The file extension with a leading dot.
		/// </summary>
		public string FileExtension { get; }

		/// <summary>
		/// Initialize the result with the information.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		/// <param name="filePath">The full file-path.</param>
		/// <param name="fileExtension">The file extension with a leading dot.</param>
		public BytesResult(byte[] bytes, string filePath, string fileExtension)
		{
			Bytes = bytes;
			FilePath = filePath;
			FileExtension = fileExtension;
		}
	}
}

