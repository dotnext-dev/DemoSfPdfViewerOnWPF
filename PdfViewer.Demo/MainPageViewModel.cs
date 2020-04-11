using System.IO;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace PdfViewer.Demo
{
    class MainPageViewModel : BindableObject
    {
        private ICommand _togglePdfCommand;
        private Stream _pdfDocumentStream;

        /// <summary>
        /// The PDF document stream that is loaded into the instance of the PDF viewer. 
        /// </summary>
        public Stream PdfDocumentStream
        {
            get
            {
                return _pdfDocumentStream;
            }
            set
            {
                _pdfDocumentStream = value;
                OnPropertyChanged();
            }
        }

        public ICommand TogglePdfCommand =>
            _togglePdfCommand ??
            (_togglePdfCommand = new Command(RefreshPdfDocumentStream));

        void RefreshPdfDocumentStream()
        {
            if (PdfDocumentStream == null)
            {
                PdfDocumentStream = typeof(App).GetTypeInfo()
                    .Assembly.GetManifestResourceStream("PdfViewer.Demo.DummyFile.pdf");
            }
            else
                PdfDocumentStream = null;
        }
    }
}
