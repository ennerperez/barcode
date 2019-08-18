namespace Barcode
{
    /// <summary>
    /// Represents a barcode symbology where characters have different two
    /// width settings and a variable number of encoding bits.
    /// </summary>
    public class BinaryPitchVaryLengthGlyph : BinaryPitchGlyph, IVaryLengthGlyph
    {
        #region Private Fields

        private short _bitEncodingWidth;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Barcode.BinaryPitchGlyph"/>
        /// class.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="bitEncoding">The bit encoding.</param>
        /// <param name="widthEncoding">The width encoding.</param>
        /// <param name="bitEncodingWidth">The bit encoding width expressed as a number of bits.</param>
        public BinaryPitchVaryLengthGlyph(char character, short bitEncoding,
            short widthEncoding, short bitEncodingWidth)
            : base(character, bitEncoding, widthEncoding)
        {
            _bitEncodingWidth = bitEncodingWidth;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the number of bits used for the bit encoding.
        /// </summary>
        /// <value>The width encoding.</value>
        public short BitEncodingWidth
        {
            get
            {
                return _bitEncodingWidth;
            }
        }

        #endregion Public Properties
    }
}