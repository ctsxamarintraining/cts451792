using System;
using Xamarin.Forms;
using SQLite;

namespace PlayerApp
{
	public interface IGalleryImageService
	{
		void SelectImage();

		event EventHandler<ImageSourceEventArgs> ImageSelected;
	}

	public class ImageSourceEventArgs : EventArgs
	{
		public ImageSourceEventArgs(ImageSource imageSource)
		{
			if (imageSource == null) throw new ArgumentNullException("imageSource");

			ImageSource = imageSource;
		}

		public ImageSource ImageSource { get; private set; }
	}
}

