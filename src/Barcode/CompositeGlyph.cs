namespace Barcode
{
    /// <summary>
    /// Represents a composite glyph.
    /// </summary>
    /// <remarks>
    /// Composite glyphs are used exclusively to represent traps for
    /// implementing full ASCII encoding mechanisms used in a variety of
    /// barcode symbologies. Both Code 39 and Code 93 use this scheme.
    /// </remarks>
    public class CompositeGlyph : Glyph
    {
        #region Private Fields

        private BarGlyph _first;
        private BarGlyph _second;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Barcode.CompositeGlyph"/>
        /// class.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        public CompositeGlyph(char character, BarGlyph first, BarGlyph second)
            : base(character)
        {
            _first = first;
            _second = second;
        }

        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the first <see cref="T:Barcode.BarGlyph"/> object.
        /// </summary>
        /// <value>A <see cref="T:Barcode.BarGlyph"/>.</value>
        public BarGlyph First
        {
            get
            {
                return _first;
            }
        }

        /// <summary>
        /// Gets the second <see cref="T:Barcode.BarGlyph"/> object.
        /// </summary>
        /// <value>A <see cref="T:Barcode.BarGlyph"/>.</value>
        public BarGlyph Second
        {
            get
            {
                return _second;
            }
        }

        #endregion Public Properties
    }
}