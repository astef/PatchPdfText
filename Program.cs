using System;
using System.IO;
using CommandLine;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Font;
using iText.StyledXmlParser.Resolver.Font;

namespace PatchPdfText
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(o =>
            {
                PdfDocument pdfDoc;
                if (o.File == null)
                {
                    pdfDoc = new PdfDocument(
                        new PdfReader(o.InputFile),
                        new PdfWriter(o.OutputFile));
                }
                else
                {
                    pdfDoc = new PdfDocument(
                        new PdfReader(new MemoryStream(File.ReadAllBytes(o.File))),
                        new PdfWriter(o.File));
                }

                Document doc = new Document(pdfDoc);

                FontSet fs = new FontSet();
                if (o.FontPath != null)
                    fs.AddFont(o.FontPath);
                var provider = new BasicFontProvider(fs, o.FontFamily);
                doc.SetFontProvider(provider);

                var para = new Paragraph(o.Text);

                para.SetFontFamily(o.FontFamily);
                para.SetFontSize(o.FontSize);
                para.SetFontColor(GetColor(o.FontColor));

                para.SetBackgroundColor(GetColor(o.BackgroundColor), o.BackgroundOpacity);

                para.SetFixedPosition(o.Page, o.Left, o.Bottom, o.Width);

                doc.Add(para);

                doc.Flush();
                doc.Close();
            });
        }

        private static Color GetColor(string hex)
        {
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return new DeviceRgb(r, g, b);
        }

        public sealed class Options
        {
            [Option("file", Required = true, SetName = "singleFile", HelpText = "Input and output PDF file to read from and write to.")]
            public string File { get; set; }

            [Option("input", Required = true, SetName = "twoFiles", HelpText = "Input PDF file to read from.")]
            public string InputFile { get; set; }

            [Option("output", Required = true, SetName = "twoFiles", HelpText = "Output PDF file to write to.")]
            public string OutputFile { get; set; }

            [Option("text", Required = true, HelpText = "Text to be added to the PDF file.")]
            public string Text { get; set; }

            [Option("font-path", HelpText = "Path to ttf file to use.")]
            public string FontPath { get; set; }

            [Option("font-family", Required = true, HelpText = "Typeface to be used for the patch text.")]
            public string FontFamily { get; set; }

            [Option("font-size", Required = true, HelpText = "Size of the patch font.")]
            public float FontSize { get; set; }

            [Option("font-color", Default = "000000", HelpText = "HEX-formatted RGB color of the patch font.")]
            public string FontColor { get; set; }

            [Option("bg-color", Default = "FFFFFF", HelpText = "HEX-formatted RGB color of the patch background.")]
            public string BackgroundColor { get; set; }

            [Option("bg-opacity", Default = 100, HelpText = "Opacity of the patch background.")]
            public float BackgroundOpacity { get; set; }

            [Option("page", Default = 1, HelpText = "Page where to place the patch.")]
            public int Page { get; set; }

            [Option("left", Required = true, HelpText = "X coordinate of the patch.")]
            public float Left { get; set; }

            [Option("bottom", Required = true, HelpText = "Y coordinate of the patch.")]
            public float Bottom { get; set; }

            [Option("width", Required = true, HelpText = "Width of the patch.")]
            public float Width { get; set; }
        }

    }
}
