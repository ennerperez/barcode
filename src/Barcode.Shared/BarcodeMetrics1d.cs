using System;

namespace Barcode
{
    /// <summary>
    /// <c>BarcodeMetrics1d</c> defines the measurement metrics used to render
    /// a 1 dimensional barcode.
    /// </summary>
    [Serializable]
    public class BarcodeMetrics1d : BarcodeMetrics
    {
        #region Private Fields

        private int _minWidth;
        private int _maxWidth;
        private int _minHeight;
        private int _maxHeight;
        private int? _interGlyphSpacing;
        private bool _renderVertically;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeMetrics1d"/> class.
        /// </summary>
        public BarcodeMetrics1d()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeMetrics1d"/> class.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public BarcodeMetrics1d(int width, int height)
        {
            _minWidth = _maxWidth = width;
            _minHeight = _maxHeight = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeMetrics1d"/> class.
        /// </summary>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        /// <param name="height"></param>
        public BarcodeMetrics1d(int minWidth, int maxWidth, int height)
        {
            _minWidth = minWidth;
            _maxWidth = maxWidth;
            _minHeight = _maxHeight = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BarcodeMetrics1d"/> class.
        /// </summary>
        /// <param name="minWidth"></param>
        /// <param name="maxWidth"></param>
        /// <param name="minHeight"></param>
        /// <param name="maxHeight"></param>
        public BarcodeMetrics1d(int minWidth, int maxWidth, int minHeight, int maxHeight)
        {
            _minWidth = minWidth;
            _maxWidth = maxWidth;
            _minHeight = minHeight;
            _maxHeight = maxHeight;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets/sets the minimum bar width.
        /// </summary>
        public int MinWidth
        {
            get
            {
                return _minWidth;
            }
            set
            {
                _minWidth = value;
            }
        }

        /// <summary>
        /// Gets/sets the maximum bar width.
        /// </summary>
        public int MaxWidth
        {
            get
            {
                return _maxWidth;
            }
            set
            {
                _maxWidth = value;
            }
        }

        /// <summary>
        /// Gets/sets the minimum bar height.
        /// </summary>
        public int MinHeight
        {
            get
            {
                return _minHeight;
            }
            set
            {
                _minHeight = value;
            }
        }

        /// <summary>
        /// Gets/sets the maximum bar height.
        /// </summary>
        public int MaxHeight
        {
            get
            {
                return _maxHeight;
            }
            set
            {
                _maxHeight = value;
            }
        }

        /// <summary>
        /// Gets/sets the amount of inter-glyph spacing to apply.
        /// </summary>
        /// <remarks>
        /// By default this is set to -1 which forces the barcode drawing
        /// classes to use the default value specified by the symbology.
        /// </remarks>
        public int? InterGlyphSpacing
        {
            get
            {
                return _interGlyphSpacing;
            }
            set
            {
                _interGlyphSpacing = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to render the barcode vertically.
        /// </summary>
        /// <value>
        /// <c>true</c> to render barcode vertically; otherwise, <c>false</c>.
        /// </value>
        public bool RenderVertically
        {
            get
            {
                return _renderVertically;
            }
            set
            {
                _renderVertically = value;
            }
        }

        #endregion Public Properties
    }
}