using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public static class PrinterDirector
    {
        public static PrinterBase GetStandardOfficePrinter(string model, PrinterBuilder builder)
        {
            return builder.SetModel(model)
                          .SetFormat(PrintFormat.A4)
                          .SetPrintTechnology(new LaserPrint())
                          .Build();
        }

        public static PrinterBase GetPhotoPrinter(string model, PrinterBuilder builder)
        {
            return builder.SetModel(model)
                          .SetFormat(PrintFormat.A3)
                          .SetPrintTechnology(new SublimationPrint())
                          .Build();
        }

        public static PrinterBase GetLargeFormatPrinter(string model, PrinterBuilder builder)
        {
            return builder.SetModel(model)
                          .SetFormat(PrintFormat.LargeFormat44)
                          .SetPrintTechnology(new InkjetPrint())
                          .Build();
        }
    }
}
