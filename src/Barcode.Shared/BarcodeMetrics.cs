using System;

namespace Barcode
{
    /// <summary>
    /// <c>BarcodeMetrics</c> defines the measurement metrics used to render
    /// a barcode.
    /// </summary>
    [Serializable]
    public abstract class BarcodeMetrics
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeMetrics"/> class.
        /// </summary>
        protected BarcodeMetrics()
        {
            Scale = 1;
        }

        /// <summary>
        /// Gets or sets the scale factor used to render a barcode.
        /// </summary>
        /// <value>The scale.</value>
        /// <remarks>
        /// When applied to a 1D barcode the scale is used to scale the width
        /// of barcode elements not the height.
        /// When applied to a 2D barcode the scale adjusts both width and height
        /// of barcode elements.
        /// </remarks>
        public int Scale
        {
            get;
            set;
        }
    }
}