using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class PhotoPrinterBuilder : PrinterBuilder
    {
        public override PrinterBase Build()
        {
            var printer = new PhotoPrinter { Model = model, Format = format };
            if (technology != null)
            {
                printer.SetPrintTechnology(technology);
            }
            return printer;
        }
    }
}
