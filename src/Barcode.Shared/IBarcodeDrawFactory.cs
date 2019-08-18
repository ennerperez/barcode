namespace Barcode
{
    public interface IBarcodeDrawFactory
    {
        BarcodeDraw GetSymbology(BarcodeSymbology symbology);
    }
}