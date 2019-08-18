namespace Barcode
{
    /// <summary>
    /// <b>BarGlyph</b> extends the <see cref="T:Barcode.Glyph"/> base
    /// class and adds a bit-encoding to describe a bar-code glyph.
    /// </summary>
    public class BarGlyph : Glyph, IBarGlyph
    {
        #region Private Fields

        private short _bitEncoding;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="T:Barcode.Glyph"/>
        /// class with the specified bit encoding.
        /// </summary>
        /// <param name="character">Character represented by glyph.</param>
        /// <param name="bitEncoding">The bit-encoding value for this character.</param>
        public BarGlyph(char character, short bitEncoding)
            : base(character)
        {
            _bitEncoding = bitEncoding;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the bit encoding for this glyph.
        /// </summary>
        /// <value>A <see cref="T:System.Int16"/> representing the bit encoding.</value>
        public short BitEncoding
        {
            get
            {
                return _bitEncoding;
            }
        }

        #endregion Public Properties
    }
}