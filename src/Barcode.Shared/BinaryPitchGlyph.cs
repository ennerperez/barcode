namespace Barcode
{
    /// <summary>
	/// <b>BinaryPitchGlyph</b> represents a two-state variable pitched
	/// barcode glyph characters (Code 3 of 9 is a good example) where
	/// character bars or spaces can be one of two widths.
	/// </summary>
	public class BinaryPitchGlyph : BarGlyph, IBinaryPitchGlyph
    {
        #region Private Fields

        private short _widthEncoding;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Barcode.BinaryPitchGlyph"/>
        /// class.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="bitEncoding">The bit encoding.</param>
        /// <param name="widthEncoding">The width encoding.</param>
        public BinaryPitchGlyph(char character, short bitEncoding,
            short widthEncoding)
            : base(character, bitEncoding)
        {
            _widthEncoding = widthEncoding;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the width encoding.
        /// </summary>
        /// <value>The width encoding.</value>
        public short WidthEncoding
        {
            get
            {
                return _widthEncoding;
            }
        }

        #endregion Public Properties
    }
}