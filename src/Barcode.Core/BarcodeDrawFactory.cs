using System;

namespace Barcode
{
    /// <summary>
    /// <b>BarcodeDrawFactory</b> returns draw agents capable of generating
    /// the appropriate bar-code image.
    /// </summary>
    public class BarcodeDrawFactory<TBarcodeDraw, TGlyphFactory, TFactoryChecksum> : IBarcodeDrawFactory
        where TBarcodeDraw : BarcodeDraw
        where TGlyphFactory : GlyphFactory
        where TFactoryChecksum : FactoryChecksum<TGlyphFactory>
    {
        #region Private Fields

        private static TBarcodeDraw _codeWithoutChecksum;
        private static TBarcodeDraw _codeWithChecksum;

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        /// Gets an agent capable of rendering a Code39 barcode without
        /// adding a checksum glyph.
        /// </summary>
        /// <value>A <see cref="T:Barcode.Code39BarcodeDraw"/> object.</value>
        public static TBarcodeDraw CodeWithoutChecksum
        {
            get
            {
                if (_codeWithoutChecksum == null)
                    _codeWithoutChecksum = (TBarcodeDraw)Activator.CreateInstance(typeof(TBarcodeDraw), typeof(TGlyphFactory).GetProperty("Instance").GetValue(null, null));
                return _codeWithoutChecksum;
            }
        }

        /// <summary>
        /// Gets an agent capable of rendering a Code39 barcode with an
        /// added checksum glyph.
        /// </summary>
        /// <value>A <see cref="T:Barcode.Code39BarcodeDraw"/> object.</value>
        public static TBarcodeDraw CodeWithChecksum
        {
            get
            {
                if (_codeWithChecksum == null)
                    _codeWithChecksum = (TBarcodeDraw)Activator.CreateInstance(typeof(TBarcodeDraw), typeof(TFactoryChecksum).GetProperty("Instance").GetValue(null, null));
                return _codeWithChecksum;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the barcode drawing object for rendering the specified
        /// barcode symbology.
        /// </summary>
        /// <param name="symbology">
        /// A value from the <see cref="T:Barcode.BarcodeSymbology"/> enumeration.
        /// </param>
        /// <returns>
        /// A class derived from <see cref="T:Barcode.BarcodeDraw"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">
        /// Thrown if the specified symbology is invalid or unknown.
        /// </exception>
        public BarcodeDraw GetSymbology(BarcodeSymbology symbology)
        {
            switch (symbology)
            {
                case BarcodeSymbology.WithoutChecksum:
                    return CodeWithoutChecksum;

                case BarcodeSymbology.WithChecksum:
                    return CodeWithChecksum;

                default:
                    throw new ArgumentException("Invalid barcode symbology encountered.", "symbology");
            }
        }

        #endregion Public Methods
    }
}