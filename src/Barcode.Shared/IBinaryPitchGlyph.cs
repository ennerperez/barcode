namespace Barcode
{
    /// <summary>
    /// <c>IBinaryPitchGlyph</c> defines the contract with binary pitched
    /// glyphs.
    /// </summary>
    public interface IBinaryPitchGlyph : IBarGlyph
    {
        /// <summary>
        /// Gets the width encoding.
        /// </summary>
        /// <value>The width encoding.</value>
        short WidthEncoding
        {
            get;
        }
    }
}