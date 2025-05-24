using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class LargeFormatPrinterBuilder : PrinterBuilder
    {
        public override PrinterBase Build()
        {
            var printer = new LargeFormatPrinter { Model = model, Format = format };
            if (technology != null)
            {
                printer.SetPrintTechnology(technology);
            }
            return printer;
        }
    }
}
