namespace Barcode
{
    /// <summary>
    /// <c>BarcodeSymbology</c> defines the supported barcode symbologies.
    /// </summary>
    public enum BarcodeSymbology
    {
        /// <summary>
        /// Unknown symbology.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Code without checksum
        /// </summary>
        WithoutChecksum = 1,

        /// <summary>
        /// Code with checksum
        /// </summary>
        WithChecksum = 2,
    }
}