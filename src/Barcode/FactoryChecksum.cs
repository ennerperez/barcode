namespace Barcode
{
    /// <summary>
    /// <b>FactoryChecksum</b> defines the base class for all checksum classes
    /// that are attached to an object derived from <see cref="T:Barcode.GlyphFactory"/>
    /// for fetching the checksum glyph characters.
    /// </summary>
    /// <typeparam name="T">
    /// A factory class derived from <see cref="T:Barcode.GlyphFactory"/>.
    /// </typeparam>
    public abstract class FactoryChecksum<T> : Checksum where T : GlyphFactory
    {
        #region Private Fields

        private T _factory;

        #endregion Private Fields

        #region Protected Constructors

        /// <summary>
        /// Initialises a new instance of <see cref="T:Barcode.FactoryChecksum"/>
        /// class with the specified <see cref="T:Barcode.GlyphFactory"/> derived
        /// object.
        /// </summary>
        /// <param name="factory">
        /// Factory to associate with the checksum generator.
        /// </param>
        protected FactoryChecksum(T factory)
        {
            _factory = factory;
        }

        #endregion Protected Constructors

        #region Public Properties

        /// <summary>
        /// Gets the <typeparamref name="T"/> type-safe glyph factory.
        /// </summary>
        /// <value>The <typeparamref name="T" /> factory.</value>
        public T Factory
        {
            get
            {
                return _factory;
            }
        }

        #endregion Public Properties
    }
}