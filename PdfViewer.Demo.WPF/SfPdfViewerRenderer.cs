using System;
using Xamarin.Forms.Platform.WPF;
using Syncfusion.SfPdfViewer.XForms;
using PdfViewer.Demo.WPF;
using System.ComponentModel;

    [assembly: ExportRenderer(typeof(SfPdfViewer), typeof(SfPdfViewerRenderer))]
    namespace PdfViewer.Demo.WPF
    {
        public class SfPdfViewerRenderer
            : ViewRenderer<SfPdfViewer, Syncfusion.Windows.PdfViewer.PdfViewerControl>
        {
            Syncfusion.Windows.PdfViewer.PdfViewerControl _nativeControl;

            protected override void OnElementChanged(ElementChangedEventArgs<SfPdfViewer> e)
            {
                base.OnElementChanged(e);

                // If new forms element attached, wire up the native control
                if (e.NewElement != null)
                {
                    _nativeControl = new Syncfusion.Windows.PdfViewer.PdfViewerControl();
                    SetNativeControl(_nativeControl);
                }
                // Otherwise perform some cleanup
                else
                {
                    if(_nativeControl != null)
                    {
                        _nativeControl.Unload();
                        _nativeControl = null;
                    }
                }

                UpdateNativeControlProperties();
            }

            /// <summary>
            /// Basically sync property values from forms-element (SfPdfViewer) 
            /// to native-control (PdfViewerControl)
            /// In this example - we only sync with 'input file stream'
            /// </summary>
            private void UpdateNativeControlProperties()
            {
                if (Element != null && Element.InputFileStream != null)
                {
                    Control.Load(Element.InputFileStream);
                }
                else
                {
                    Control.Unload();
                }
            }

            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);

                if (e.PropertyName == nameof(SfPdfViewer.InputFileStream))
                {
                    UpdateNativeControlProperties();
                }
            }
        }
    }
