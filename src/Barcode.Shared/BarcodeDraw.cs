using System.Drawing;

namespace Barcode
{
    /// <summary>
    /// <c>BarcodeDraw</c> is an abstract base class for all barcode drawing
    /// classes.
    /// </summary>
    public abstract class BarcodeDraw
    {
        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="T:Barcode.BarcodeDraw"/> class.
        /// </summary>
        protected BarcodeDraw()
        {
        }

        #endregion Protected Constructors

        #region Public Methods

        /// <summary>
        /// Draws the specified text using the supplied barcode metrics.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="metrics">A <see cref="T:Barcode.BarcodeMetrics"/> object.</param>
        /// <returns>
        /// An <see cref="Image"/> object containing the rendered barcode.
        /// </returns>
        public abstract Image Draw(string text, BarcodeMetrics metrics);

        /// <summary>
        /// Draws the specified text using the default barcode metrics for
        /// the specified maximum barcode height.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="maxBarHeight">The maximum bar height.</param>
        /// <returns>
        /// An <see cref="Image"/> object containing the rendered barcode.
        /// </returns>
        public Image Draw(string text, int maxBarHeight)
        {
            BarcodeMetrics defaultMetrics = GetDefaultMetrics(maxBarHeight);
            return Draw(text, defaultMetrics);
        }

        /// <summary>
        /// Draws the specified text using the default barcode metrics for
        /// the specified maximum barcode height.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="maxBarHeight">The maximum bar height.</param>
        /// <param name="scale">
        /// The scale factor to use when rendering the barcode.
        /// </param>
        /// <returns>
        /// An <see cref="Image"/> object containing the rendered barcode.
        /// </returns>
        public Image Draw(string text, int maxBarHeight, int scale)
        {
            BarcodeMetrics defaultMetrics = GetDefaultMetrics(maxBarHeight);
            defaultMetrics.Scale = scale;
            return Draw(text, defaultMetrics);
        }

        /// <summary>
        /// Gets a <see cref="T:Barcode.BarcodeMetrics"/> object containing default
        /// settings for the specified maximum bar height.
        /// </summary>
        /// <param name="maxHeight">The maximum barcode height.</param>
        /// <returns>A <see cref="T:Barcode.BarcodeMetrics"/> object.</returns>
        public abstract BarcodeMetrics GetDefaultMetrics(int maxHeight);

        /// <summary>
        /// Gets a <see cref="T:BarcodeMetrics"/> object containing the print
        /// metrics needed for printing a barcode of the specified physical
        /// size on a device operating at the specified resolution.
        /// </summary>
        /// <param name="desiredBarcodeDimensions">The desired barcode dimensions in hundredth of an inch.</param>
        /// <param name="printResolution">The print resolution in pixels per inch.</param>
        /// <param name="barcodeCharLength">Length of the barcode in characters.</param>
        /// <returns>A <see cref="T:Barcode.BarcodeMetrics"/> object.</returns>
        public abstract BarcodeMetrics GetPrintMetrics(
            Size desiredBarcodeDimensions, Size printResolution,
            int barcodeCharLength);

        #endregion Public Methods
    }
}