namespace Barcode
{
    /// <summary>
    /// <b>Checksum</b> defines the base class for generating the bar-code
    /// glyphs needed for adding checksum information.
    /// </summary>
    /// <remarks>
    /// To implement a checksum class derived instances must implement the
    /// sole abstract method <see cref="M:Barcode.Checksum.GetChecksum"/>.
    /// </remarks>
    public abstract class Checksum
    {
        #region Protected Constructors

        /// <summary>
        /// Initialises a new instance of <see cref="T:Barcode.Checksum"/> class.
        /// </summary>
        protected Checksum()
        {
        }

        #endregion Protected Constructors

        #region Public Methods

        /// <summary>
        /// Gets an array of <see cref="T:Barcode.Glyph"/> objects that
        /// represent the checksum for the specified text string.
        /// </summary>
        /// <param name="text">Text to be processed.</param>
        /// <returns>
        /// A collection of <see cref="T:BarcodeGlyph"/> objects
        /// representing the checksum information.
        /// </returns>
        public virtual Glyph[] GetChecksum(string text)
        {
            return GetChecksum(text, false);
        }

        /// <summary>
        /// Gets an array of <see cref="T:Barcode.Glyph"/> objects that
        /// represent the checksum for the specified text string.
        /// </summary>
        /// <param name="text">Text to be processed.</param>
        /// <param name="allowComposite">if set to <c>true</c> to allow use of
        /// composite glyphs.</param>
        /// <returns>
        /// A collection of <see cref="T:Barcode.Glyph"/> objects
        /// representing the checksum information.
        /// </returns>
        public virtual Glyph[] GetChecksum(string text, bool allowComposite)
        {
            return new Glyph[0];
        }

        #endregion Public Methods
    }
}