using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Barcode
{
    /// <summary>
    /// <b>Code128BarcodeDraw</b> is a type-safe extension of <see cref="T:BarcodeDraw"/>
    /// that can render complete Code128 barcodes with checksum.
    /// </summary>
    public class Code128BarcodeDraw
        : BarcodeDrawBase<Code128GlyphFactory, Code128Checksum>
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Code128BarcodeDraw"/>
        /// class.
        /// </summary>
        /// <param name="checksum">The checksum.</param>
        public Code128BarcodeDraw(Code128Checksum checksum)
            : base(checksum.Factory, checksum, 11)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        /// <summary>
        /// Overridden. Gets a <see cref="T:BarcodeMetrics"/> object
        /// containing default settings for the specified maximum bar height.
        /// </summary>
        /// <param name="maxHeight">The maximum barcode height.</param>
        /// <returns>
        /// A <see cref="T:BarcodeMetrics"/> object.
        /// </returns>
        public override BarcodeMetrics GetDefaultMetrics(int maxHeight)
        {
            return new BarcodeMetrics1d(1, maxHeight);
        }

        /// <summary>
        /// Overridden. Gets a <see cref="T:BarcodeMetrics"/> object containing the print
        /// metrics needed for printing a barcode of the specified physical
        /// size on a device operating at the specified resolution.
        /// </summary>
        /// <param name="desiredBarcodeDimensions">The desired barcode dimensions in hundredth of an inch.</param>
        /// <param name="printResolution">The print resolution in pixels per inch.</param>
        /// <param name="barcodeCharLength">Length of the barcode in characters.</param>
        /// <returns>
        /// A <see cref="T:BarcodeMetrics"/> object.
        /// </returns>
        public override BarcodeMetrics GetPrintMetrics(
            Size desiredBarcodeDimensions, Size printResolution,
            int barcodeCharLength)
        {
            int maxHeight = desiredBarcodeDimensions.Height * printResolution.Height / 100;
            int narrowBarWidth = (printResolution.Width * desiredBarcodeDimensions.Width) /
                (100 * (24 + (barcodeCharLength * 11)));
            return new BarcodeMetrics1d(narrowBarWidth, maxHeight);
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Overridden. Gets the glyphs needed to render a full barcode.
        /// </summary>
        /// <param name="text">Text to convert into bar-code.</param>
        /// <returns>A collection of <see cref="T:Glyph"/> objects.</returns>
        protected override Glyph[] GetFullBarcode(string text)
        {
            List<Glyph> result = new List<Glyph>();
            result.AddRange(Factory.GetGlyphs(text));
            if (Checksum != null)
            {
                result.AddRange(Checksum.GetChecksum(text));
            }
            result.Add(Factory.GetRawGlyph(106));   // Stop
            result.Add(Factory.GetRawGlyph(107));   // Terminator
            return result.ToArray();
        }

        /// <summary>
        /// Overridden. Gets the length in pixels needed to render the
        /// specified barcode.
        /// </summary>
        /// <param name="barcode">Barcode glyphs to be analysed.</param>
        /// <param name="interGlyphSpace">Amount of inter-glyph space.</param>
        /// <param name="barMinWidth">Minimum bar width.</param>
        /// <param name="barMaxWidth">Maximum bar width.</param>
        /// <returns></returns>
        protected override int GetBarcodeLength(Glyph[] barcode,
            int interGlyphSpace, int barMinWidth, int barMaxWidth)
        {
            return base.GetBarcodeLength(barcode, interGlyphSpace,
                barMinWidth, barMaxWidth) - (9 * barMinWidth);
        }

        #endregion Protected Methods
    }
}