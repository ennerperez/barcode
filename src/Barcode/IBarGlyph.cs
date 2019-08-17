namespace Barcode
{
    /// <summary>
    /// <c>IBarGlyph</c> extends <see cref="T:Barcode.IGlyph"/> by
    /// specifying a bit encoding for a given character.
    /// The bits indicate where bars are drawn.
    /// </summary>
    public interface IBarGlyph : IGlyph
    {
        /// <summary>
        /// Gets the bit encoding.
        /// </summary>
        /// <value>The bit encoding.</value>
        short BitEncoding
        {
            get;
        }
    }
}