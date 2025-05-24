using lab9;
using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        var printers = new List<PrinterBase>();
        var officeBuilder = new OfficePrinterBuilder();
        var largeFormatBuilder = new LargeFormatPrinterBuilder();
        var photoBuilder = new PhotoPrinterBuilder();

        printers.AddRange(new PrinterBase[] {
            PrinterDirector.GetStandardOfficePrinter("HP LaserJet", officeBuilder),
            PrinterDirector.GetPhotoPrinter("Canon Pixma", photoBuilder),
            PrinterDirector.GetLargeFormatPrinter("Epson SureColor", largeFormatBuilder)
        });

        foreach (var printer in printers)
        {
            printer.GetInfo();
            printer.Print();

            if (printer is ISortFunction sortPrinter)
            {
                sortPrinter.SortDocuments();
            }

            if (printer is IRollPrint rollPrinter)
            {
                rollPrinter.PrintFromRoll();
            }

            if (printer is IWebInterface webPrinter)
            {
                webPrinter.AccessWebInterface();
            }

            Console.WriteLine("---");
        }
    }
}