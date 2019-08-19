
![logo](src/.editoricon.png)

# Barcode .NET
Barcode for .NET Framework and .NET Core

[![Build status](https://ci.appveyor.com/api/projects/status/ama5i4gum8q98sj8?svg=true)](https://ci.appveyor.com/project/ennerperez/barcode)
[![NuGet](http://img.shields.io/nuget/v/barcode.net.svg)](https://www.nuget.org/packages/barcode.net/)

---------------------------------------

See the [changelog](CHANGELOG.md) for changes.

---------------------------------------

## Roadmap

### Main features
- [x] .NET Framework Implementation
- [x] .NET Core Implementation
- [ ] Samples & Tools

### Implementation
- [ ] Code11
- [x] Code128
- [ ] Code25
- [ ] Code39
- [ ] Code93
- [ ] Ean13
- [ ] Ean8
- [ ] PDF417
- [ ] QR

### Implementing

**Add the library to your project**

Add the [NuGet Package](https://www.nuget.org/packages/barcode.net/). Right click on your project and click 'Manage NuGet Packages...'. Search for 'barcode.net' and click on install. Once installed the library will be included in your project references. (Or install it through the package manager console: PM> Install-Package barcode.net)

```CSharp
var code128 = new Barcode.Code128DrawFactory();
var drawObject = code128.GetSymbology(Barcode.BarcodeSymbology.WithChecksum);
var metrics = drawObject.GetDefaultMetrics(200);
metrics.Scale = 2;
var barcode = drawObject.Draw("Demo", metrics);
barcode.Save("demo.bmp");
```

### Bugs and feature requests

Have a bug or a feature request? Please first search for existing and closed issues. If your problem or idea is not addressed yet, [please open a new issue](https://github.com/ennerperez/System.Drawing.Pictograms/issues/new).

### Documentation

No more documentation required for now.

### License

Code released under [The MIT License](LICENSE)